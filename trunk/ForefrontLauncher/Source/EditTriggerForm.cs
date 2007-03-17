using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Triggers;

namespace ForefrontLauncher {

	public partial class EditTriggerForm : Form {

		public EditTriggerForm() {
			InitializeComponent();
		}

		public TriggerType TriggerType {
			set {
				switch ( value ) {
					case TriggerType.Key:
						this.ComboBoxTriggerType.SelectedIndex = 0;
						break;
					case TriggerType.MouseInCorner:
						this.ComboBoxTriggerType.SelectedIndex = 1;
						break;
				}
				//this.ComboBoxTriggerType.SelectedItem = value;
			}
		}

		public object TriggerValue {
			set {
				for ( int i = 0; i < this.ComboBoxTriggerValue.Items.Count; i++ ) {
					if ( this.ComboBoxTriggerValue.Items[i].ToString() == value.ToString() ) {
						this.ComboBoxTriggerValue.SelectedIndex = i;
						break;
					}
				}
			}
		}

		public string TriggerString {
			get {
				return this.ComboBoxTriggerType.Text + " " + this.ComboBoxTriggerValue.Text;
			}
		}

		private void ComboBoxTriggerType_SelectedIndexChanged(object sender, EventArgs e) {
			if ( this.ComboBoxTriggerType.SelectedIndex == 0 ) {
				this.ComboBoxTriggerValue.Items.Clear();
				foreach ( object o in Enum.GetValues(typeof(TriggerKeys)) ) {
					this.ComboBoxTriggerValue.Items.Add(o);
				}
			} else if ( this.ComboBoxTriggerType.SelectedIndex == 1 ) {
				this.ComboBoxTriggerValue.Items.Clear();
				foreach ( object o in Enum.GetValues(typeof(MouseCorner)) ) {
					this.ComboBoxTriggerValue.Items.Add(o);
				}
			}
		}

		private void ButtonOk_Click(object sender, EventArgs e) {
			if ( this.ComboBoxTriggerType.Text == string.Empty ) {
				MessageBox.Show("Select a trigger type.");
				return;
			}

			if ( this.ComboBoxTriggerValue.Text == string.Empty ) {
				MessageBox.Show("Select a trigger value.");
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}