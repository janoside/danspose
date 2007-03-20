using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VistaDwmApi {

	[StructLayout(LayoutKind.Sequential)]
	public struct Rect {

		public Rect(int left, int top, int right, int bottom) {
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}
}
