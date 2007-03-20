using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using VistaDwmApi;

namespace Dansposé {
	
	public static class Utility {

		public static Rectangle RectangleFromRect(Rect rect) {
			return new Rectangle(
				rect.Left,
				rect.Top,
				rect.Right - rect.Left,
				rect.Bottom - rect.Top);
		}

		public static Rect RectFromRectangle(Rectangle rect) {
			return new Rect(
				rect.X,
				rect.Y,
				rect.X + rect.Width,
				rect.Y + rect.Height);
		}

		public static Rect GetCenterRect(Rect rect) {
			return new Rect(
				(rect.Left + rect.Right) / 2, 
				(rect.Top + rect.Bottom) / 2, 
				(rect.Left + rect.Right) / 2, 
				(rect.Top + rect.Bottom) / 2);
		}
	}
}
