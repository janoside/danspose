using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DansposéLauncher {

	public partial class AboutForm : Form {

		public AboutForm() {
			InitializeComponent();
		}

		private void ButtonOk_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("http://www.janoside.com");
		}

		protected override void OnPaint(PaintEventArgs e) {
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			base.OnPaint(e);
		}
	}
}