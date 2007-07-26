using System;
using System.Collections.Generic;
using System.Text;

using VistaDwmApi;

namespace VistaDwmApi {
	
	public class VistaWindow {

		private static string GetTitle(string title) {
			switch ( title ) {
				case "Program Manager":
					return "Desktop";
				case "Player Window":
					return "Winamp";
				default:
					if ( title.Contains("Winamp") ) {
						return "Winamp";
					}
					return title;
			}
		}

		private IntPtr fHandle;

		private IntPtr fIndexPointer;

		private string fTitle;

		private ThumbnailProperties fThumbnailProperties;

		private Rect fRectangle;

		private Rect fVisibleRectangle;

		private Rect fInitialRectangle;

		private PSize fSize;

		private PSize fScaledSize;

		private float fOpacity;

		private long fApplicationInstance;

		private bool fIsMinimized;

		public VistaWindow(IntPtr handle, string title) {
			this.fHandle = handle;
			this.fOpacity = 1;

			this.fScaledSize = new PSize();
			this.fRectangle = new Rect(0, 0, 0, 0);
			this.fApplicationInstance = User32.GetWindowLong(this.Handle, VistaDwm.GWL_HINSTANCE);
			
			this.fThumbnailProperties = new ThumbnailProperties();
			this.fThumbnailProperties.fVisible = true;
			this.fThumbnailProperties.dwFlags = VistaDwm.DWM_TNP_VISIBLE | VistaDwm.DWM_TNP_RECTDESTINATION | VistaDwm.DWM_TNP_OPACITY;

			this.RefreshVisibleProperties(title);
		}

		/// <summary>
		/// Used when the VistaWindow needs to poll any visible properties.
		/// </summary>
		public void RefreshVisibleProperties(string title) {
			this.fTitle = VistaWindow.GetTitle(title);
			User32.GetWindowRect(this.Handle, ref this.fInitialRectangle);
			this.fIsMinimized = (this.fInitialRectangle.Left == -32000 && this.fInitialRectangle.Top == -32000);
		}

		public IntPtr Handle {
			get {
				return this.fHandle;
			}
		}

		public IntPtr IndexPointer {
			get {
				return this.fIndexPointer;
			}
			set {
				this.fIndexPointer = value;
			}
		}

		public Rect Rectangle {
			get {
				return this.fRectangle;
			}
			set {
				this.fRectangle = value;
				this.UpdateThumbnail();
			}
		}

		public Rect InitialRectangle {
			get {
				return this.fInitialRectangle;
			}
			set {
				this.fInitialRectangle = value;
			}
		}

		public PSize Size {
			get {
				return this.fSize;
			}
		}

		public PSize ScaledSize {
			get {
				return this.fScaledSize;
			}
		}

		public string Title {
			get {
				return this.fTitle;
			}
		}

		public long ApplicationInstance {
			get {
				return this.fApplicationInstance;
			}
		}

		public float Opacity {
			get {
				return this.fOpacity;
			}
			set {
				this.fOpacity = value;
				if ( this.fOpacity < 0 ) {
					this.fOpacity = 0;
				}
				if ( this.fOpacity > 1 ) {
					this.fOpacity = 1;
				}
				this.fThumbnailProperties.opacity = (byte)(255 * this.fOpacity);
				DwmApi.DwmUpdateThumbnailProperties(this.fIndexPointer, ref this.fThumbnailProperties);
			}
		}

		public bool IsMinimized {
			get {
			//	return this.fIsMinimized;
				long style = User32.GetWindowLong(this.fHandle, VistaDwm.GWL_STYLE);
				return (((ulong)style & VistaDwm.WS_MINIMIZE) == VistaDwm.WS_MINIMIZE);
			}
		}

		public override string ToString() {
			return this.fTitle;
		}

		public bool RegisterTo(IntPtr windowHandle) {
			return (DwmApi.DwmRegisterThumbnail(windowHandle, this.Handle, out this.fIndexPointer) == 0);
		}

		public void Unregister() {
			DwmApi.DwmUnregisterThumbnail(this.fIndexPointer);
		}

		public void UpdateThumbnail() {
			DwmApi.DwmQueryThumbnailSourceSize(this.fIndexPointer, out this.fSize);

			int rectWidth = (this.fRectangle.Right - this.fRectangle.Left);
			int rectHeight = (this.fRectangle.Bottom - this.fRectangle.Top);

			float xScale = rectWidth / (float)this.fSize.X;
			float yScale = rectHeight / (float)this.fSize.Y;

			int realWidth = rectWidth;
			int realHeight = rectHeight;

			if ( xScale < 1 && yScale < 1 ) {
				if ( xScale > yScale ) {
					realWidth = (int)(this.fSize.X * yScale);
					realHeight = rectHeight;
				} else {
					realWidth = rectWidth;
					realHeight = (int)(this.fSize.Y * xScale);
				}
			} else if ( xScale <  1 && yScale >= 1 ) {
				realWidth = rectWidth;
				realHeight = (int)(this.fSize.Y * xScale);
			} else if ( xScale >= 1 && yScale < 1 ) {
				// scaling down in y direction
				realHeight = rectHeight;
				realWidth = (int)(this.fSize.X * yScale);
			} else {
				realWidth = this.fSize.X;
				realHeight = this.fSize.Y;
			}

			this.fScaledSize.X = realWidth;
			this.fScaledSize.Y = realHeight;
			
			this.fThumbnailProperties.rcDestination.Left = this.fRectangle.Left + (rectWidth - realWidth) / 2;
			this.fThumbnailProperties.rcDestination.Right = this.fThumbnailProperties.rcDestination.Left + realWidth;
			this.fThumbnailProperties.rcDestination.Top = this.fRectangle.Top + (rectHeight - realHeight) / 2;
			this.fThumbnailProperties.rcDestination.Bottom = this.fThumbnailProperties.rcDestination.Top + realHeight;

			DwmApi.DwmUpdateThumbnailProperties(this.fIndexPointer, ref this.fThumbnailProperties);
		}

		public void BringToFront(IntPtr handle) {
			this.Unregister();
			this.RegisterTo(handle);
			this.UpdateThumbnail();
		}

		public bool IsCovering(int x, int y, bool visible) {
			if ( visible ) {
				return (
					x >= this.fThumbnailProperties.rcDestination.Left &&
					x <= this.fThumbnailProperties.rcDestination.Right &&
					y >= this.fThumbnailProperties.rcDestination.Top &&
					y <= this.fThumbnailProperties.rcDestination.Bottom);
			} else {
				return (
					x >= this.fRectangle.Left &&
					x <= this.fRectangle.Right &&
					y >= this.fRectangle.Top &&
					y <= this.fRectangle.Bottom);
			}
		}

		public Rect VisibleRectangle {
			get {
				return this.fThumbnailProperties.rcDestination;
			}
		}

		public void Minimize() {
			User32.ShowWindow(this.fHandle, VistaDwm.SW_FORCEMINIMIZE);
		}
	}
}
