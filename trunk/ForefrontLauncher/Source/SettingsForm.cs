using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Forefront;
using ForefrontLauncher;

namespace ForefrontLauncher {

	public partial class SettingsForm : Form {

		private App fApp;

		private GroupPanel fSelectedGroupPanel;

		private TriggerPanel fSelectedTriggerPanel;

		private List<Control> fGroupControls;

		private object val;

		public SettingsForm(App app) {
			this.fApp = app;
			this.fGroupControls = new List<Control>();

			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			DataTable groupTable = new DataTable();
			groupTable.Columns.Add("String(s) to Match", typeof(string));
			groupTable.Columns.Add("Group Name", typeof(string));

		//	DataTable triggerTable = new DataTable();
		//	triggerTable.Columns.Add("Trigger Type", typeof(TriggerType));
		//	triggerTable.Columns.Add("Trigger Value", typeof(string));

			ConfigurationSettings settings = SerializationUtility.DeserializeXmlObject<ConfigurationSettings>(Application.StartupPath + "\\Settings.xml");
			foreach ( string group in settings.Groups ) {
				DataRow dr = groupTable.NewRow();
				dr["String(s) to Match"] = group.Substring(0, group.IndexOf("/")).Replace(",", "\n");
				dr["Group Name"] = group.Substring(group.IndexOf("/") + 1);
				groupTable.Rows.Add(dr);

				this.AddGroup(group);
			}

			int triggerIndex = 0;
			foreach ( string trigger in settings.Triggers ) {
				this.AddTrigger(trigger);
			}

			this.ValueAnimationLength.Value = (int)(settings.AnimationLength * 1000);
			this.ValueBackgroundOpacity.Value = (decimal)settings.BackgroundOpacity;
			this.ValueThumbnailOpacity.Value = (decimal)settings.ThumbnailOpacity;
			this.ValueBorderWidth.Value = settings.BorderWidth;
			this.ValueBorderHeight.Value = settings.BorderHeight;
		}

		private TriggerPanel AddTrigger(string trigger) {
			TriggerPanel triggerPanel = new TriggerPanel();
			triggerPanel.Dock = DockStyle.Top;
			triggerPanel.TriggerType = (TriggerType)Enum.Parse(typeof(TriggerType), trigger.Substring(0, trigger.IndexOf(" ")));
			triggerPanel.TriggerValue = trigger.Substring(trigger.IndexOf(" ") + 1);
			this.PanelTriggerList.Controls.Add(triggerPanel);
			triggerPanel.BringToFront();
			triggerPanel.Selected += delegate(object sender, EventArgs ea) {
				this.fSelectedTriggerPanel = (TriggerPanel)sender;
				for ( int i = 0; i < this.PanelTriggerList.Controls.Count; i++ ) {
					if ( this.PanelTriggerList.Controls[i] is TriggerPanel && this.PanelTriggerList.Controls[i] != sender ) {
						((TriggerPanel)this.PanelTriggerList.Controls[i]).Unselect();
					}
				}
			};
			triggerPanel.DoubleClick += delegate(object sender, EventArgs e) {
				EditTriggerForm etf = new EditTriggerForm();
				etf.TriggerType = ((TriggerPanel)sender).TriggerType;
				etf.TriggerValue = ((TriggerPanel)sender).TriggerValue;
				DialogResult dr = etf.ShowDialog();
				if ( dr == DialogResult.OK ) {
					//((GroupPanel)sender).GroupString = egf.GroupString;
				}
			};

			return triggerPanel;
		}

		private GroupPanel AddGroup(string group) {
			GroupPanel groupPanel = new GroupPanel();
			groupPanel.Dock = DockStyle.Top;
			groupPanel.GroupString = group;
			this.PanelGroupList.Controls.Add(groupPanel);
			groupPanel.BringToFront();
			groupPanel.Selected += delegate(object sender, EventArgs ea) {
				this.fSelectedGroupPanel = (GroupPanel)sender;
				for ( int i = 0; i < this.PanelGroupList.Controls.Count; i++ ) {
					if ( this.PanelGroupList.Controls[i] is GroupPanel && this.PanelGroupList.Controls[i] != sender ) {
						((GroupPanel)this.PanelGroupList.Controls[i]).Unselect();
					}
				}
			};
			groupPanel.DoubleClick += delegate(object sender, EventArgs e) {
				EditGroupForm egf = new EditGroupForm();
				egf.GroupString = ((GroupPanel)sender).GroupString;
				DialogResult dr = egf.ShowDialog();
				if ( dr == DialogResult.OK ) {
					((GroupPanel)sender).GroupString = egf.GroupString;
				}
			};

			this.fGroupControls.Add(groupPanel);

			return groupPanel;
		}

		private void ButtonOk_Click(object sender, EventArgs e) {
			ConfigurationSettings settings = new ConfigurationSettings();
			
		//	DataTable groupTable = (DataTable)this.DataGridGroups.DataSource;
		//	foreach ( DataRow dr in groupTable.Rows ) {
		//		settings.Groups.Add(dr[0].ToString() + "/" + dr[1].ToString());
		//	}
			foreach ( Control c in this.fGroupControls ) {
				settings.Groups.Add(((GroupPanel)c).GroupString);
			}

			foreach ( Control c in this.PanelTriggerList.Controls ) {
				settings.Triggers.Add(((TriggerPanel)c).TriggerString);
			}

			//DataTable triggerTable = (DataTable)this.DataGridTriggers.DataSource;
			//foreach ( DataRow dr in triggerTable.Rows ) {
			//	settings.Triggers.Add(dr[0].ToString() + " " + dr[1].ToString());
			//}
		//	for ( int i = 0; i < this.DataGridTriggers.Rows.Count - 1; i++ ) {
		//		settings.Triggers.Add(this.DataGridTriggers.Rows[i].Cells[0].Value.ToString() + " " + this.DataGridTriggers.Rows[i].Cells[1].Value.ToString());
		//	}

			settings.AnimationLength = (float)this.ValueAnimationLength.Value / 1000.0f;
			settings.BackgroundOpacity = (float)this.ValueBackgroundOpacity.Value;
			settings.ThumbnailOpacity = (float)this.ValueThumbnailOpacity.Value;
			settings.BorderWidth = (int)this.ValueBorderWidth.Value;
			settings.BorderHeight = (int)this.ValueBorderHeight.Value;

			SerializationUtility.SaveObjectToFile(settings, Application.StartupPath + "\\Settings.xml");

			this.fApp.LoadSettings();

			this.Close();
		}

		private void ButtonCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		/*private void ButtonGroupUpClick(object sender, EventArgs e) {
			DataTable dt = (DataTable)this.DataGridGroups.DataSource;
			int index = this.DataGridGroups.SelectedRows[0].Index;

			if ( index > 0 ) {
				object[] items = dt.Rows[index].ItemArray;
				dt.Rows.RemoveAt(index);
				DataRow dr = dt.NewRow();
				dr.ItemArray = items;
				dt.Rows.InsertAt(dr, index - 1);

				this.DataGridGroups.DataSource = dt;
				this.DataGridGroups.Rows[index - 1].Selected = true;
			}
		}

		private void ButtonGroupDownClick(object sender, EventArgs e) {
			DataTable dt = (DataTable)this.DataGridGroups.DataSource;
			int index = this.DataGridGroups.SelectedRows[0].Index;

			if ( index < (this.DataGridGroups.Rows.Count - 2) ) {
				object[] items = dt.Rows[index].ItemArray;
				dt.Rows.RemoveAt(index);
				DataRow dr = dt.NewRow();
				dr.ItemArray = items;
				dt.Rows.InsertAt(dr, index + 1);

				this.DataGridGroups.DataSource = dt;
				this.DataGridGroups.Rows[index + 1].Selected = true;
			}
		}*/

		protected override void OnPaint(PaintEventArgs e) {
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			base.OnPaint(e);
		}

		private void ButtonGroupUpClick(object sender, EventArgs e) {
			int index = this.fGroupControls.IndexOf(this.fSelectedGroupPanel);
			if ( index > 0 ) {
				this.fGroupControls.Remove(this.fSelectedGroupPanel);
				this.fGroupControls.Insert(index - 1, this.fSelectedGroupPanel);

				foreach ( Control c in this.fGroupControls ) {
					c.BringToFront();
				}
			}
		}

		private void ButtonGroupDownClick(object sender, EventArgs e) {
			int index = this.fGroupControls.IndexOf(this.fSelectedGroupPanel);
			if ( index < this.fGroupControls.Count - 1 ) {
				this.fGroupControls.Remove(this.fSelectedGroupPanel);
				this.fGroupControls.Insert(index + 1, this.fSelectedGroupPanel);

				foreach ( Control c in this.fGroupControls ) {
					c.BringToFront();
				}
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e) {
			EditGroupForm egf = new EditGroupForm();
			DialogResult dr = egf.ShowDialog();
			if ( dr == DialogResult.OK ) {
				this.AddGroup(egf.GroupString).Highlight();
			}
		}

		private void toolStripButton4_Click(object sender, EventArgs e) {
			EditTriggerForm etf = new EditTriggerForm();
			DialogResult dr = etf.ShowDialog();
			if ( dr == DialogResult.OK ) {
				this.AddTrigger(etf.TriggerString);
			}
		}

		private void ButtonDeleteGroupClick(object sender, EventArgs e) {
			if ( this.fSelectedGroupPanel != null ) {
				int index = this.fGroupControls.IndexOf(this.fSelectedGroupPanel);

				this.fGroupControls.Remove(this.fSelectedGroupPanel);
				this.PanelGroupList.Controls.Remove(this.fSelectedGroupPanel);

				if ( index >= this.fGroupControls.Count ) {
					index--;
					if ( index == -1 ) {
						this.fSelectedGroupPanel = null;
						return;
					}
				}

				this.fSelectedGroupPanel = (GroupPanel)this.fGroupControls[index];
				this.fSelectedGroupPanel.Highlight();

				this.Refresh();
			}
		}

		private void ButtonDeleteTriggerClick(object sender, EventArgs e) {
			if ( this.fSelectedTriggerPanel != null ) {
				int index = this.PanelTriggerList.Controls.IndexOf(this.fSelectedTriggerPanel);

				this.PanelTriggerList.Controls.Remove(this.fSelectedTriggerPanel);

				if ( index >= this.PanelTriggerList.Controls.Count ) {
					index--;
					if ( index == -1 ) {
						this.fSelectedTriggerPanel = null;
						return;
					}
				}

				this.fSelectedTriggerPanel = (TriggerPanel)this.PanelTriggerList.Controls[index];
				this.fSelectedTriggerPanel.Highlight();

				this.Refresh();
			}
		}
	}
}