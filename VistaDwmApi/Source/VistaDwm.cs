using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VistaDwmApi {
	
	public class VistaDwm {

		#region Constants

		public static readonly int GWL_STYLE = -16;

		public const int DWM_TNP_VISIBLE = 0x8;
		public const int DWM_TNP_OPACITY = 0x4;
		public const int DWM_TNP_RECTDESTINATION = 0x1;

		public const ulong WS_VISIBLE = 0x10000000L;
		public const ulong WS_BORDER = 0x00800000L;
		public const ulong WS_MINIMIZE = 0x20000000L;

		public const int GWL_HINSTANCE = -6;

		public const int SW_RESTORE = 9;
		public const int SW_FORCEMINIMIZE = 11;

		public static readonly ulong TARGETWINDOW = WS_BORDER | WS_VISIBLE;

		#endregion

		private static List<VistaWindow> cachedWindows;

		public static VistaWindow[] GetVisibleWindows() {
			cachedWindows = new List<VistaWindow>();
			User32.EnumWindows(EnumWindowCallback, 0);

			cachedWindows.Sort(delegate(VistaWindow vw1, VistaWindow vw2) {
				return vw1.Title.CompareTo(vw2.Title);
			});

			return cachedWindows.ToArray();
		}

		private static bool EnumWindowCallback(IntPtr hwnd, int lParam) {
			if ( /*hwnd != fExposéWindowHandle &&*/ (User32.GetWindowLongA(hwnd, VistaDwm.GWL_STYLE) & VistaDwm.WS_VISIBLE) == VistaDwm.WS_VISIBLE ) {
				StringBuilder sb = new StringBuilder(1000);
				User32.GetWindowText(hwnd, sb, sb.Capacity);

				if ( sb.ToString() == "Program Manager" || (User32.GetWindowLongA(hwnd, VistaDwm.GWL_STYLE) & VistaDwm.WS_VISIBLE) == VistaDwm.WS_VISIBLE ) {

					VistaWindow window = new VistaWindow(hwnd, sb.ToString());
					IntPtr parentHwnd = User32.GetParent(hwnd);
					if ( window.Title.Length > 0 && IsValidTitle(window.Title) && parentHwnd == IntPtr.Zero ) {
						cachedWindows.Add(window);
					}
				}
			}

			//continue enumeration
			return true;
		}

		private static bool IsValidTitle(string title) {
			switch ( title ) {
			//	case "Start":
			//		return false;
				case "Cisco Clean Access Agent":
					return false;
				default:
					if ( title != "Winamp" && title.EndsWith("Winamp") ) {
						return false;
					}
					return true;
			}
		}

		public static void MinimizeAllWindows() {
			Shell32.ShellClass objShel = new Shell32.ShellClass();
			((Shell32.IShellDispatch4)objShel).MinimizeAll();
		}
	}
}
