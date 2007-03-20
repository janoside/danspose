using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VistaDwmApi {
	
	public static class DwmApi {

		[DllImport("dwmapi.dll")]
		public static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);

		[DllImport("dwmapi.dll")]
		public static extern int DwmUnregisterThumbnail(IntPtr thumb);

		[DllImport("dwmapi.dll")]
		public static extern int DwmQueryThumbnailSourceSize(IntPtr thumb, out PSize size);

		[DllImport("dwmapi.dll")]
		public static extern int DwmUpdateThumbnailProperties(IntPtr hThumb, ref ThumbnailProperties props);

		[DllImport("dwmapi.dll")]
		public static extern void DwmExtendFrameIntoClientArea(System.IntPtr hWnd, ref Margins pMargins);

		[DllImport("dwmapi.dll")]
		public static extern void DwmIsCompositionEnabled(ref bool isEnabled);
	}
}
