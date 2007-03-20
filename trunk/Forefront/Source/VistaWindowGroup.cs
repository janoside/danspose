using System;
using System.Collections.Generic;
using System.Text;

using VistaDwmApi;

namespace Dansposé {
	
	public class VistaWindowGroup {

		private string fName;

		private string[] fMatchStrings;

		private List<VistaWindow> fWindows;

		private long fApplicationInstance;

		public VistaWindowGroup(string name) {
			this.fMatchStrings = name.Substring(0, name.IndexOf("/")).Split(',');
			this.fName = name.Substring(name.IndexOf("/") + 1);
			this.fWindows = new List<VistaWindow>();
			this.fApplicationInstance = -1;
		}

		public VistaWindowGroup(long appId) {
			this.fApplicationInstance = appId;
			this.fWindows = new List<VistaWindow>();
			this.fName = string.Empty;
		}

		public VistaWindow this[int i] {
			get {
				return this.fWindows[i];
			}
		}

		public string Name {
			get {
				return this.fName;
			}
		}

		public IEnumerable<VistaWindow> Windows {
			get {
				return this.fWindows;
			}
		}

		public int WindowCount {
			get {
				return this.fWindows.Count;
			}
		}

		public void AddWindow(VistaWindow window) {
			this.fWindows.Add(window);
		}

		public void Clear() {
			this.fWindows.Clear();
		}

		public bool Accepts(VistaWindow window) {
			if ( this.fApplicationInstance == -1 ) {
				foreach ( string matchString in this.fMatchStrings ) {
					if ( window.Title.Contains(matchString) ) {
						return true;
					}
				}
				return false;

			} else {
				return (window.ApplicationInstance == this.fApplicationInstance);
			}
		}

		public override string ToString() {
			return this.fName;
		}
	}
}
