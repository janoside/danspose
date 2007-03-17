using System;
using System.Collections.Generic;
using System.Text;

using VistaDwmApi;

namespace Forefront {

	public class WindowOpacityTransition : ITransition {

		private VistaWindow fWindow;

		private float fStartOpacity;

		private float fEndOpacity;

		public WindowOpacityTransition(VistaWindow window, float start, float end) {
			this.fWindow = window;
			this.fStartOpacity = start;
			this.fEndOpacity = end;
		}

		public float Progress {
			set {
				if ( value >= 0 && value <= 1 ) {
					this.fWindow.Opacity = this.fStartOpacity * (1 - value) + this.fEndOpacity * value;
					this.fWindow.UpdateThumbnail();
				}
			}
		}

		public void End() {
			this.fWindow.Opacity = this.fEndOpacity;
			this.fWindow.UpdateThumbnail();
		}
	}
}
