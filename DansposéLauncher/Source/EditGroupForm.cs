using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DansposéLauncher {

	public partial class EditGroupForm : Form {

		public EditGroupForm() {
			InitializeComponent();
		}

		public string GroupString {
			get {
				string s = string.Empty;
				for ( int i = 0; i < this.richTextBox1.Lines.Length; i++ ) {
					if ( this.richTextBox1.Lines[i].Length > 0 ) {
						s += this.richTextBox1.Lines[i];
						if ( i < this.richTextBox1.Lines.Length - 1 ) {
							s += ",";
						}
					}
				}

				if ( s.EndsWith(",") ) {
					s = s.Substring(0, s.Length - 1);
				}

				s += "/";
				s += this.textBox1.Text;

				return s;
			}
			set {
				this.textBox1.Text = value.Substring(value.IndexOf("/") + 1);
				this.richTextBox1.Lines = value.Substring(0, value.IndexOf("/")).Split(',');
			}
		}

		private void ButtonOk_Click(object sender, EventArgs e) {
			if ( this.textBox1.Text.Length == 0 ) {
				MessageBox.Show("Group name length must be longer than 0");
				this.textBox1.Focus();
			} else {
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}