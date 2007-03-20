using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using VistaDwmApi;

namespace Dansposé {
	
	public class VistaWindowManager {

		private List<VistaWindow> fWindows;

		private List<VistaWindowGroup> fGroups;

		private List<VistaWindowGroup> fActiveGroups;

		private List<IntPtr> fSkipHandles;

		private Dictionary<Point, object> fObjectsByPosition;

		private Dictionary<VistaWindow, Rect> fOriginalWindowLocations;

		private Queue<VistaWindow> fWindowQueue;

		private Queue<VistaWindowGroup> fWindowGroupQueue;

		private VistaWindow fDesktopWindow;

		private VistaWindow fDesktopWindowThumbnail;

		private int fObjectCount;

		private bool fGivenDesktop;

		public VistaWindowManager(IntPtr[] skipHandles, IEnumerable<string> groups) {
			this.fSkipHandles = new List<IntPtr>(skipHandles);
			this.fWindows = new List<VistaWindow>();
			this.fGroups = new List<VistaWindowGroup>();
			this.fActiveGroups = new List<VistaWindowGroup>();
			this.fObjectsByPosition = new Dictionary<Point, object>();
			this.fWindowQueue = new Queue<VistaWindow>();
			this.fWindowGroupQueue = new Queue<VistaWindowGroup>();
			this.fOriginalWindowLocations = new Dictionary<VistaWindow, Rect>();

			foreach ( string groupName in groups ) {
				this.fGroups.Add(new VistaWindowGroup(groupName));
			}
		}

		public object this[int i] {
			get {
				if ( this.fDesktopWindowThumbnail == null ) {
					return this.fWindows[i];
				} else {
					if ( i == 0 && this.fDesktopWindowThumbnail != null ) {
						return this.fDesktopWindowThumbnail;
					} else if ( i < (this.fActiveGroups.Count + 1) ) {
						return this.fActiveGroups[i - 1];
					} else if ( i < (this.fWindows.Count + this.fActiveGroups.Count + 1) ) {
						return this.fWindows[i - this.fActiveGroups.Count - 1];
					} else {
						return null;
					}
				}
			}
		}

		public IEnumerable<VistaWindow> Windows {
			get {
				if ( this.fDesktopWindowThumbnail != null ) {
					yield return this.fDesktopWindowThumbnail;
				}

				foreach ( VistaWindow vw in this.fWindows ) {
					yield return vw;
				}
			}
		}

		public IEnumerable<VistaWindowGroup> ActiveGroups {
			get {
				return this.fActiveGroups;
			}
		}

		public IEnumerable<VistaWindowGroup> Groups {
			get {
				return this.fGroups;
			}
		}

		public VistaWindow DesktopWindow {
			get {
				return this.fDesktopWindow;
			}
		}

		public int WindowCount {
			get {
				return this.fWindows.Count;
			}
		}

		public int GroupCount {
			get {
				return this.fGroups.Count;
			}
		}

		public int ObjectCount {
			get {
				return this.fObjectCount;
			}
		}

		public void RefreshWindows() {
			this.RefreshWindows(VistaDwm.GetVisibleWindows(), true, true);
		}

		public void RefreshWindows(IEnumerable<VistaWindow> windows, bool addDesktop, bool sortByGroup) {
			this.fGivenDesktop = false;
			this.fOriginalWindowLocations.Clear();
			this.fActiveGroups.Clear();

			// group by application
			if ( false ) {
				this.fGroups.Clear();
				List<long> apps = new List<long>();
				foreach ( VistaWindow vw in windows ) {
					if ( !apps.Contains(vw.ApplicationInstance) ) {
						apps.Add(vw.ApplicationInstance);
					}
				}

				foreach ( long appId in apps ) {
					this.fGroups.Add(new VistaWindowGroup(appId));
				}
			}

			foreach ( VistaWindow vw in this.fWindows ) {
				vw.Unregister();
			}

			this.fWindows.Clear();
			foreach ( VistaWindowGroup group in this.fGroups ) {
				group.Clear();
			}

			Rect rect = new Rect();
			foreach ( VistaWindow vw in windows ) {
				User32.GetWindowRect(vw.Handle, ref rect);
				this.fOriginalWindowLocations.Add(vw, rect);

				if ( !this.fSkipHandles.Contains(vw.Handle) ) {
					if ( vw.Title == "Desktop" ) {
						this.fDesktopWindow = vw;
						if ( addDesktop ) {
							this.fDesktopWindowThumbnail = new VistaWindow(vw.Handle, vw.Title);
						//	this.fWindows.Add(this.fDesktopWindowThumbnail);

							User32.GetWindowRect(this.fDesktopWindowThumbnail.Handle, ref rect);
							this.fOriginalWindowLocations.Add(this.fDesktopWindowThumbnail, rect);
						}
					} else {
						bool accepted = false;
						if ( sortByGroup ) {
							foreach ( VistaWindowGroup group in this.fGroups ) {
								if ( group.Accepts(vw) ) {
									accepted = true;
									group.AddWindow(vw);
								}
							}
						}

						if ( !accepted ) {
							this.fWindowQueue.Enqueue(vw);
							this.fWindows.Add(vw);
						}
					}
				}
			}

			foreach ( VistaWindowGroup group in this.fGroups ) {
				if ( group.WindowCount > 0 ) {
					this.fActiveGroups.Add(group);
					this.fWindowGroupQueue.Enqueue(group);
				}
			}

			this.fObjectCount = this.fWindowQueue.Count + this.fWindowGroupQueue.Count;
			if ( addDesktop ) {
				this.fObjectCount++;
			}
		}

		public object GetNextObject() {
			if ( !this.fGivenDesktop && this.fDesktopWindowThumbnail != null ) {
				this.fGivenDesktop = true;
				return this.fDesktopWindowThumbnail;
			} else {
				if ( this.fWindowGroupQueue.Count > 0 ) {
					return this.fWindowGroupQueue.Dequeue();
				} else if ( this.fWindowQueue.Count > 0 ) {
					return this.fWindowQueue.Dequeue();
				} else {
					return null;
				}
			}
		}

		public void UnregisterAll() {
			if ( this.fDesktopWindowThumbnail != null ) {
				this.fDesktopWindowThumbnail.Unregister();
			}
			if ( this.fDesktopWindow != null ) {
				this.fDesktopWindow.Unregister();
			}
			foreach ( VistaWindow vw in this.fWindows ) {
				vw.Unregister();
			}
			foreach ( VistaWindowGroup group in this.fGroups ) {
				foreach ( VistaWindow vw in group.Windows ) {
					vw.Unregister();
				}
			}
		}

		public Rect GetOriginalLocation(VistaWindow vw) {
			return this.fOriginalWindowLocations[vw];
		}
	}
}
