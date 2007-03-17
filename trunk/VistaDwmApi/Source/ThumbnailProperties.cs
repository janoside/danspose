using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VistaDwmApi {

	[StructLayout(LayoutKind.Sequential)]
	public struct ThumbnailProperties {

		public int dwFlags;

		public Rect rcDestination;

		public Rect rcSource;

		public byte opacity;

		public bool fVisible;

		public bool fSourceClientAreaOnly;
	}
}
