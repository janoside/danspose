using System;
using System.Collections.Generic;
using System.Text;

using VistaDwmApi;

namespace Dansposé {
	
	public class WindowPositionTransition : ITransition {

		private VistaWindow fWindow;

		private Rect fStartRect;

		private Rect fEndRect;

		public WindowPositionTransition(VistaWindow window, Rect start, Rect end) {
			this.fWindow = window;
			this.fStartRect = start;
			this.fEndRect = end;
		}

		public float Progress {
			set {
				if ( value >= 0 && value <= 1 ) {
					this.fWindow.Rectangle = new Rect(
						(int)(this.fStartRect.Left * (1 - value) + this.fEndRect.Left * value),
						(int)(this.fStartRect.Top * (1 - value) + this.fEndRect.Top * value),
						(int)(this.fStartRect.Right * (1 - value) + this.fEndRect.Right * value),
						(int)(this.fStartRect.Bottom * (1 - value) + this.fEndRect.Bottom * value));

					//this.fWindow.UpdateThumbnail();
				}
			}
		}

		public void End() {
			this.fWindow.Rectangle = this.fEndRect;
			this.fWindow.UpdateThumbnail();
		}
	}
}
