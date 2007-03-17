using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Triggers {
	
	public class MouseInCornerTrigger : Trigger, IMouseListener {

		private MouseCorner fCorner;

		private int fHotspotSize;

		public MouseInCornerTrigger(MouseCorner corner) {
			this.fCorner = corner;
			this.fHotspotSize = 5;
		}

		#region IMouseListener Members

		public void OnMouseActivity(MouseEventArgs mea) {
			switch ( this.fCorner ) {
				case MouseCorner.TopLeft:
					if ( mea.X <= this.fHotspotSize && mea.Y <= this.fHotspotSize ) {
						this.OnTriggered();
					}
					break;
				case MouseCorner.TopRight:
					if ( mea.X >= (Screen.PrimaryScreen.Bounds.Width - this.fHotspotSize) && mea.Y <= this.fHotspotSize ) {
						this.OnTriggered();
					}
					break;
				case MouseCorner.BottomLeft:
					if ( mea.X <= this.fHotspotSize && mea.Y >= (Screen.PrimaryScreen.Bounds.Height - this.fHotspotSize) ) {
						this.OnTriggered();
					}
					break;
				case MouseCorner.BottomRight:
					if ( mea.X >= (Screen.PrimaryScreen.Bounds.Width - this.fHotspotSize) && mea.Y >= (Screen.PrimaryScreen.Bounds.Height - this.fHotspotSize) ) {
						this.OnTriggered();
					}
					break;
			}
		}

		#endregion
	}
}
