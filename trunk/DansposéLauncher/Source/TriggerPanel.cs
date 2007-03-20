using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DansposéLauncher {

	public partial class TriggerPanel : Panel {

		public event EventHandler Selected;

		private TriggerType fTriggerType;

		private object fTriggerValue;

		private Color fHighlightColor;

		public TriggerPanel() {
			this.BackgroundImageLayout = ImageLayout.Stretch;
			this.fHighlightColor = Color.FromArgb(191, 239, 255);
			this.Height = 25;

			this.MouseDown += this.Select;
		}

		public TriggerType TriggerType {
			get {
				return this.fTriggerType;
			}
			set {
				this.fTriggerType = value;
			}
		}

		public object TriggerValue {
			get {
				return this.fTriggerValue;
			}
			set {
				this.fTriggerValue = value;
			}
		}

		public string TriggerString {
			get {
				return this.fTriggerType.ToString() + " " + this.fTriggerValue.ToString();
			}
		}

		private void Select(object o, MouseEventArgs e) {
			this.BackgroundImage = Properties.Resources.SelectedGradient;

			if ( this.Selected != null ) {
				this.Selected(this, EventArgs.Empty);
			}
		}

		public void Highlight() {
			this.Select(this, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
		}

		internal void Unselect() {
			this.BackgroundImage = null;
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			e.Graphics.DrawLine(Pens.Silver, 0, this.Height - 1, this.Width, this.Height - 1);
			e.Graphics.DrawString(this.fTriggerType.ToString(), this.Font, Brushes.Black, 3, 3);
			e.Graphics.DrawString(this.fTriggerValue.ToString(), this.Font, Brushes.Black, 195, 3);
		}
	}
}
