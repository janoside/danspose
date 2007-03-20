
namespace DansposéLauncher {

	partial class EditTriggerForm {

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if ( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ComboBoxTriggerType = new System.Windows.Forms.ComboBox();
			this.ComboBoxTriggerValue = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Location = new System.Drawing.Point(174, 146);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.ButtonCancel.TabIndex = 0;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// ButtonOk
			// 
			this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonOk.Location = new System.Drawing.Point(93, 146);
			this.ButtonOk.Name = "ButtonOk";
			this.ButtonOk.Size = new System.Drawing.Size(75, 23);
			this.ButtonOk.TabIndex = 1;
			this.ButtonOk.Text = "Ok";
			this.ButtonOk.UseVisualStyleBackColor = true;
			this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Trigger Type";
			// 
			// ComboBoxTriggerType
			// 
			this.ComboBoxTriggerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ComboBoxTriggerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxTriggerType.FormattingEnabled = true;
			this.ComboBoxTriggerType.Items.AddRange(new object[] {
            "Key",
            "MouseInCorner"});
			this.ComboBoxTriggerType.Location = new System.Drawing.Point(15, 25);
			this.ComboBoxTriggerType.Name = "ComboBoxTriggerType";
			this.ComboBoxTriggerType.Size = new System.Drawing.Size(234, 21);
			this.ComboBoxTriggerType.TabIndex = 3;
			this.ComboBoxTriggerType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTriggerType_SelectedIndexChanged);
			// 
			// ComboBoxTriggerValue
			// 
			this.ComboBoxTriggerValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ComboBoxTriggerValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxTriggerValue.FormattingEnabled = true;
			this.ComboBoxTriggerValue.Location = new System.Drawing.Point(15, 82);
			this.ComboBoxTriggerValue.Name = "ComboBoxTriggerValue";
			this.ComboBoxTriggerValue.Size = new System.Drawing.Size(234, 21);
			this.ComboBoxTriggerValue.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Trigger Value";
			// 
			// EditTriggerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 181);
			this.Controls.Add(this.ComboBoxTriggerValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ComboBoxTriggerType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ButtonOk);
			this.Controls.Add(this.ButtonCancel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "EditTriggerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Trigger";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ComboBoxTriggerType;
		private System.Windows.Forms.ComboBox ComboBoxTriggerValue;
		private System.Windows.Forms.Label label2;
	}
}