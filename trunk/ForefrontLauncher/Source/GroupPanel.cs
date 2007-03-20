using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DansposéLauncher {

	public partial class GroupPanel : Panel {

		public event EventHandler Selected;

		private string fGroupString;

		private string fName;

		private string fMatches;

		private Color fHighlightColor;

		public GroupPanel() {
			this.BackgroundImageLayout = ImageLayout.Stretch;
			this.fHighlightColor = Color.FromArgb(191, 239, 255);

			this.MouseDown += this.Select;
		}

		public string GroupString {
			get {
				return this.fGroupString;
			}
			set {
				this.fGroupString = value;

				this.fName = value.Substring(value.IndexOf("/") + 1);
				this.fMatches = value.Substring(0, value.IndexOf("/")).Replace(",", "\n");

				this.Height = (int)this.CreateGraphics().MeasureString(this.fMatches, this.Font).Height + 6 + (int)(2.6f * this.fMatches.Split('\n').Length);
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
			e.Graphics.DrawString(this.fName, this.Font, Brushes.Black, 3, 3);
			e.Graphics.DrawString(this.fMatches, this.Font, Brushes.Black, 195, 3);
		}
	}
}
