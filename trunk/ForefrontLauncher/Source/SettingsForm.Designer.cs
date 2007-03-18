namespace ForefrontLauncher {
	partial class SettingsForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.ButtonOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ValueAnimationLength = new System.Windows.Forms.NumericUpDown();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.PanelGroupBack = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.PanelGroupList = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.DataGridGroups = new System.Windows.Forms.DataGridView();
			this.ToolStripGroups = new System.Windows.Forms.ToolStrip();
			this.ButtonNewGroup = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ButtonGroupUp = new System.Windows.Forms.ToolStripButton();
			this.ButtonGroupDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ButtonDeleteGroup = new System.Windows.Forms.ToolStripButton();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ValueThumbnailOpacity = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.ValueBorderHeight = new System.Windows.Forms.NumericUpDown();
			this.ValueBackgroundOpacity = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ValueBorderWidth = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.PanelTriggerList = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.PanelTriggerHeaderSeparator = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.ToolStripTriggers = new System.Windows.Forms.ToolStrip();
			this.ButtonNewTrigger = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ButtonDeleteTrigger = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.ButtonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ValueAnimationLength)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.PanelGroupBack.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridGroups)).BeginInit();
			this.ToolStripGroups.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ValueThumbnailOpacity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueBorderHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueBackgroundOpacity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueBorderWidth)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel7.SuspendLayout();
			this.ToolStripTriggers.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonOk
			// 
			this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonOk.Location = new System.Drawing.Point(332, 395);
			this.ButtonOk.Name = "ButtonOk";
			this.ButtonOk.Size = new System.Drawing.Size(75, 23);
			this.ButtonOk.TabIndex = 2;
			this.ButtonOk.Text = "Ok";
			this.ButtonOk.UseVisualStyleBackColor = true;
			this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 270);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Animation Length (ms)";
			// 
			// ValueAnimationLength
			// 
			this.ValueAnimationLength.Location = new System.Drawing.Point(225, 268);
			this.ValueAnimationLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.ValueAnimationLength.Name = "ValueAnimationLength";
			this.ValueAnimationLength.Size = new System.Drawing.Size(120, 22);
			this.ValueAnimationLength.TabIndex = 4;
			this.ValueAnimationLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(480, 377);
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.PanelGroupBack);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(472, 351);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Groups";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// PanelGroupBack
			// 
			this.PanelGroupBack.Controls.Add(this.groupBox3);
			this.PanelGroupBack.Controls.Add(this.DataGridGroups);
			this.PanelGroupBack.Controls.Add(this.ToolStripGroups);
			this.PanelGroupBack.Controls.Add(this.label6);
			this.PanelGroupBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelGroupBack.Location = new System.Drawing.Point(0, 0);
			this.PanelGroupBack.Name = "PanelGroupBack";
			this.PanelGroupBack.Padding = new System.Windows.Forms.Padding(3);
			this.PanelGroupBack.Size = new System.Drawing.Size(472, 351);
			this.PanelGroupBack.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.PanelGroupList);
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 39);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(466, 279);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Existing Groups";
			// 
			// PanelGroupList
			// 
			this.PanelGroupList.AutoScroll = true;
			this.PanelGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelGroupList.Location = new System.Drawing.Point(3, 39);
			this.PanelGroupList.Name = "PanelGroupList";
			this.PanelGroupList.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.PanelGroupList.Size = new System.Drawing.Size(460, 237);
			this.PanelGroupList.TabIndex = 4;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 18);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(3);
			this.panel2.Size = new System.Drawing.Size(460, 21);
			this.panel2.TabIndex = 5;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Silver;
			this.panel4.Location = new System.Drawing.Point(3, 20);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(454, 1);
			this.panel4.TabIndex = 0;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(6, 3);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Group Name:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(198, 3);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "String Matches:";
			// 
			// DataGridGroups
			// 
			this.DataGridGroups.AllowUserToResizeColumns = false;
			this.DataGridGroups.AllowUserToResizeRows = false;
			this.DataGridGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridGroups.Location = new System.Drawing.Point(191, 152);
			this.DataGridGroups.MultiSelect = false;
			this.DataGridGroups.Name = "DataGridGroups";
			this.DataGridGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DataGridGroups.Size = new System.Drawing.Size(278, 166);
			this.DataGridGroups.TabIndex = 0;
			this.DataGridGroups.Visible = false;
			// 
			// ToolStripGroups
			// 
			this.ToolStripGroups.AutoSize = false;
			this.ToolStripGroups.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ToolStripGroups.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNewGroup,
            this.toolStripSeparator1,
            this.ButtonGroupUp,
            this.ButtonGroupDown,
            this.toolStripSeparator2,
            this.ButtonDeleteGroup});
			this.ToolStripGroups.Location = new System.Drawing.Point(3, 318);
			this.ToolStripGroups.Name = "ToolStripGroups";
			this.ToolStripGroups.Size = new System.Drawing.Size(466, 30);
			this.ToolStripGroups.TabIndex = 3;
			this.ToolStripGroups.Text = "toolStrip1";
			// 
			// ButtonNewGroup
			// 
			this.ButtonNewGroup.AutoSize = false;
			this.ButtonNewGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ButtonNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("ButtonNewGroup.Image")));
			this.ButtonNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonNewGroup.Name = "ButtonNewGroup";
			this.ButtonNewGroup.Size = new System.Drawing.Size(71, 20);
			this.ButtonNewGroup.Text = "New Group";
			this.ButtonNewGroup.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
			// 
			// ButtonGroupUp
			// 
			this.ButtonGroupUp.AutoSize = false;
			this.ButtonGroupUp.Image = ((System.Drawing.Image)(resources.GetObject("ButtonGroupUp.Image")));
			this.ButtonGroupUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonGroupUp.Name = "ButtonGroupUp";
			this.ButtonGroupUp.Size = new System.Drawing.Size(75, 20);
			this.ButtonGroupUp.Text = "Move Up";
			this.ButtonGroupUp.Click += new System.EventHandler(this.ButtonGroupUpClick);
			// 
			// ButtonGroupDown
			// 
			this.ButtonGroupDown.AutoSize = false;
			this.ButtonGroupDown.Image = ((System.Drawing.Image)(resources.GetObject("ButtonGroupDown.Image")));
			this.ButtonGroupDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonGroupDown.Name = "ButtonGroupDown";
			this.ButtonGroupDown.Size = new System.Drawing.Size(91, 20);
			this.ButtonGroupDown.Text = "Move Down";
			this.ButtonGroupDown.Click += new System.EventHandler(this.ButtonGroupDownClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
			// 
			// ButtonDeleteGroup
			// 
			this.ButtonDeleteGroup.AutoSize = false;
			this.ButtonDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteGroup.Image")));
			this.ButtonDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonDeleteGroup.Name = "ButtonDeleteGroup";
			this.ButtonDeleteGroup.Size = new System.Drawing.Size(96, 20);
			this.ButtonDeleteGroup.Text = "Delete Group";
			this.ButtonDeleteGroup.Click += new System.EventHandler(this.ButtonDeleteGroupClick);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(3, 3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(466, 36);
			this.label6.TabIndex = 1;
			this.label6.Text = "Windows matching a group string will be added to that group and organized togethe" +
				"r.  Groups will be displayed in the order they appear here.";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(472, 351);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Appearance";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ValueThumbnailOpacity);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.ValueBorderHeight);
			this.panel1.Controls.Add(this.ValueBackgroundOpacity);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.ValueBorderWidth);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.ValueAnimationLength);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(466, 345);
			this.panel1.TabIndex = 6;
			// 
			// ValueThumbnailOpacity
			// 
			this.ValueThumbnailOpacity.DecimalPlaces = 2;
			this.ValueThumbnailOpacity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.ValueThumbnailOpacity.Location = new System.Drawing.Point(225, 215);
			this.ValueThumbnailOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ValueThumbnailOpacity.Name = "ValueThumbnailOpacity";
			this.ValueThumbnailOpacity.Size = new System.Drawing.Size(120, 22);
			this.ValueThumbnailOpacity.TabIndex = 7;
			this.ValueThumbnailOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ValueThumbnailOpacity.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(116, 217);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Thumbnail Opacity";
			// 
			// ValueBorderHeight
			// 
			this.ValueBorderHeight.Location = new System.Drawing.Point(225, 101);
			this.ValueBorderHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.ValueBorderHeight.Name = "ValueBorderHeight";
			this.ValueBorderHeight.Size = new System.Drawing.Size(120, 22);
			this.ValueBorderHeight.TabIndex = 7;
			this.ValueBorderHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ValueBorderHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// ValueBackgroundOpacity
			// 
			this.ValueBackgroundOpacity.DecimalPlaces = 2;
			this.ValueBackgroundOpacity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.ValueBackgroundOpacity.Location = new System.Drawing.Point(225, 158);
			this.ValueBackgroundOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ValueBackgroundOpacity.Name = "ValueBackgroundOpacity";
			this.ValueBackgroundOpacity.Size = new System.Drawing.Size(120, 22);
			this.ValueBackgroundOpacity.TabIndex = 5;
			this.ValueBackgroundOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ValueBackgroundOpacity.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(107, 160);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Background Opacity";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(82, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Thumbnail Border Height";
			// 
			// ValueBorderWidth
			// 
			this.ValueBorderWidth.Location = new System.Drawing.Point(225, 46);
			this.ValueBorderWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.ValueBorderWidth.Name = "ValueBorderWidth";
			this.ValueBorderWidth.Size = new System.Drawing.Size(120, 22);
			this.ValueBorderWidth.TabIndex = 5;
			this.ValueBorderWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ValueBorderWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(85, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Thumbnail Border Width";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(472, 351);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "Triggers";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.groupBox4);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.ToolStripTriggers);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(472, 351);
			this.panel3.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.PanelTriggerList);
			this.groupBox4.Controls.Add(this.panel7);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(3, 39);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(466, 279);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Existing Groups";
			// 
			// PanelTriggerList
			// 
			this.PanelTriggerList.AutoScroll = true;
			this.PanelTriggerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelTriggerList.Location = new System.Drawing.Point(3, 39);
			this.PanelTriggerList.Name = "PanelTriggerList";
			this.PanelTriggerList.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.PanelTriggerList.Size = new System.Drawing.Size(460, 237);
			this.PanelTriggerList.TabIndex = 4;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.PanelTriggerHeaderSeparator);
			this.panel7.Controls.Add(this.label12);
			this.panel7.Controls.Add(this.label11);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(3, 18);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(3);
			this.panel7.Size = new System.Drawing.Size(460, 21);
			this.panel7.TabIndex = 5;
			// 
			// PanelTriggerHeaderSeparator
			// 
			this.PanelTriggerHeaderSeparator.BackColor = System.Drawing.Color.Silver;
			this.PanelTriggerHeaderSeparator.Location = new System.Drawing.Point(3, 20);
			this.PanelTriggerHeaderSeparator.Name = "PanelTriggerHeaderSeparator";
			this.PanelTriggerHeaderSeparator.Size = new System.Drawing.Size(454, 1);
			this.PanelTriggerHeaderSeparator.TabIndex = 0;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(6, 3);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(75, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Trigger Type:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(198, 3);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(79, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "Trigger Value:";
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(3, 3);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(466, 36);
			this.label8.TabIndex = 2;
			this.label8.Text = "Triggers activate Forefront\'s window-selection mode.  Create any number of key-pr" +
				"ess or mouse-in-corner triggers as you desire.";
			// 
			// ToolStripTriggers
			// 
			this.ToolStripTriggers.AutoSize = false;
			this.ToolStripTriggers.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ToolStripTriggers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStripTriggers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNewTrigger,
            this.toolStripSeparator3,
            this.ButtonDeleteTrigger});
			this.ToolStripTriggers.Location = new System.Drawing.Point(3, 318);
			this.ToolStripTriggers.Name = "ToolStripTriggers";
			this.ToolStripTriggers.Size = new System.Drawing.Size(466, 30);
			this.ToolStripTriggers.TabIndex = 4;
			this.ToolStripTriggers.Text = "toolStrip2";
			// 
			// ButtonNewTrigger
			// 
			this.ButtonNewTrigger.AutoSize = false;
			this.ButtonNewTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ButtonNewTrigger.Image = ((System.Drawing.Image)(resources.GetObject("ButtonNewTrigger.Image")));
			this.ButtonNewTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonNewTrigger.Name = "ButtonNewTrigger";
			this.ButtonNewTrigger.Size = new System.Drawing.Size(76, 20);
			this.ButtonNewTrigger.Text = "New Trigger";
			this.ButtonNewTrigger.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
			// 
			// ButtonDeleteTrigger
			// 
			this.ButtonDeleteTrigger.AutoSize = false;
			this.ButtonDeleteTrigger.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteTrigger.Image")));
			this.ButtonDeleteTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ButtonDeleteTrigger.Name = "ButtonDeleteTrigger";
			this.ButtonDeleteTrigger.Size = new System.Drawing.Size(101, 20);
			this.ButtonDeleteTrigger.Text = "Delete Trigger";
			this.ButtonDeleteTrigger.Click += new System.EventHandler(this.ButtonDeleteTriggerClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
			this.imageList1.Images.SetKeyName(0, "ArrowDown.png");
			this.imageList1.Images.SetKeyName(1, "ArrowUp.png");
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonCancel.Location = new System.Drawing.Point(413, 395);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.ButtonCancel.TabIndex = 9;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(504, 430);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.ButtonOk);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Forefront Settings";
			((System.ComponentModel.ISupportInitialize)(this.ValueAnimationLength)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.PanelGroupBack.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridGroups)).EndInit();
			this.ToolStripGroups.ResumeLayout(false);
			this.ToolStripGroups.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ValueThumbnailOpacity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueBorderHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueBackgroundOpacity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueBorderWidth)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.ToolStripTriggers.ResumeLayout(false);
			this.ToolStripTriggers.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ButtonOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown ValueAnimationLength;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.DataGridView DataGridGroups;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel PanelGroupBack;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.NumericUpDown ValueBorderWidth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown ValueBorderHeight;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown ValueThumbnailOpacity;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown ValueBackgroundOpacity;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ToolStrip ToolStripGroups;
		private System.Windows.Forms.ToolStripButton ButtonNewGroup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ButtonGroupUp;
		private System.Windows.Forms.ToolStripButton ButtonGroupDown;
		private System.Windows.Forms.ToolStrip ToolStripTriggers;
		private System.Windows.Forms.ToolStripButton ButtonNewTrigger;
		private System.Windows.Forms.Panel PanelGroupList;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton ButtonDeleteGroup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton ButtonDeleteTrigger;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Panel PanelTriggerList;
		private System.Windows.Forms.Panel PanelTriggerHeaderSeparator;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
	}
}