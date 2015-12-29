namespace BothezatConfig.Interface
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.revertToDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainLayout = new BothezatConfig.Interface.DoubleBufferedLayoutPanel(this.components);
			this.glControl = new OpenTK.GLControl();
			this.channelTable = new System.Windows.Forms.TableLayoutPanel();
			this.aux2Control = new BothezatConfig.Interface.ChannelControl();
			this.aux1Control = new BothezatConfig.Interface.ChannelControl();
			this.rudderControl = new BothezatConfig.Interface.ChannelControl();
			this.elevatorControl = new BothezatConfig.Interface.ChannelControl();
			this.aileronControl = new BothezatConfig.Interface.ChannelControl();
			this.throttleControl = new BothezatConfig.Interface.ChannelControl();
			this.optionsPanel = new System.Windows.Forms.TableLayoutPanel();
			this.accelOrientationButton = new System.Windows.Forms.RadioButton();
			this.orientationButton = new System.Windows.Forms.RadioButton();
			this.consoleOutputBox = new System.Windows.Forms.TextBox();
			this.configPanel = new System.Windows.Forms.TableLayoutPanel();
			this.yawPID = new BothezatConfig.Interface.PIDControl();
			this.pitchPID = new BothezatConfig.Interface.PIDControl();
			this.rollPid = new BothezatConfig.Interface.PIDControl();
			this.configValuePanel = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.mainMenu.SuspendLayout();
			this.mainLayout.SuspendLayout();
			this.channelTable.SuspendLayout();
			this.optionsPanel.SuspendLayout();
			this.configPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 60);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(54, 30);
			label3.TabIndex = 5;
			label3.Text = "Roll:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 30);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(54, 30);
			label2.TabIndex = 4;
			label2.Text = "Pitch:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(54, 30);
			label1.TabIndex = 3;
			label1.Text = "Yaw:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(1335, 24);
			this.mainMenu.TabIndex = 0;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.revertToDefaultsToolStripMenuItem});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.configToolStripMenuItem.Text = "&Config";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.loadToolStripMenuItem.Text = "&Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// revertToDefaultsToolStripMenuItem
			// 
			this.revertToDefaultsToolStripMenuItem.Name = "revertToDefaultsToolStripMenuItem";
			this.revertToDefaultsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.revertToDefaultsToolStripMenuItem.Text = "&Revert to defaults";
			this.revertToDefaultsToolStripMenuItem.Click += new System.EventHandler(this.revertToDefaultsToolStripMenuItem_Click);
			// 
			// mainLayout
			// 
			this.mainLayout.ColumnCount = 2;
			this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainLayout.Controls.Add(this.glControl, 1, 1);
			this.mainLayout.Controls.Add(this.channelTable, 1, 0);
			this.mainLayout.Controls.Add(this.optionsPanel, 1, 2);
			this.mainLayout.Controls.Add(this.consoleOutputBox, 0, 1);
			this.mainLayout.Controls.Add(this.configPanel, 0, 0);
			this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayout.Location = new System.Drawing.Point(0, 24);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.RowCount = 3;
			this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.mainLayout.Size = new System.Drawing.Size(1335, 773);
			this.mainLayout.TabIndex = 1;
			// 
			// glControl
			// 
			this.glControl.BackColor = System.Drawing.Color.Black;
			this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.glControl.Location = new System.Drawing.Point(670, 374);
			this.glControl.Name = "glControl";
			this.glControl.Size = new System.Drawing.Size(662, 365);
			this.glControl.TabIndex = 1;
			this.glControl.VSync = false;
			this.glControl.Load += new System.EventHandler(this.glControl_Load);
			this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
			this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
			// 
			// channelTable
			// 
			this.channelTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.channelTable.ColumnCount = 1;
			this.channelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.channelTable.Controls.Add(this.aux2Control, 0, 5);
			this.channelTable.Controls.Add(this.aux1Control, 0, 4);
			this.channelTable.Controls.Add(this.rudderControl, 0, 3);
			this.channelTable.Controls.Add(this.elevatorControl, 0, 2);
			this.channelTable.Controls.Add(this.aileronControl, 0, 1);
			this.channelTable.Controls.Add(this.throttleControl, 0, 0);
			this.channelTable.Location = new System.Drawing.Point(670, 3);
			this.channelTable.Name = "channelTable";
			this.channelTable.RowCount = 7;
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.channelTable.Size = new System.Drawing.Size(662, 365);
			this.channelTable.TabIndex = 2;
			// 
			// aux2Control
			// 
			this.aux2Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aux2Control.Channel = BothezatConfig.Serial.MessageData.Receiver.Channel.AUX2;
			this.aux2Control.Location = new System.Drawing.Point(3, 303);
			this.aux2Control.Name = "aux2Control";
			this.aux2Control.Size = new System.Drawing.Size(656, 54);
			this.aux2Control.TabIndex = 11;
			// 
			// aux1Control
			// 
			this.aux1Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aux1Control.Channel = BothezatConfig.Serial.MessageData.Receiver.Channel.AUX1;
			this.aux1Control.Location = new System.Drawing.Point(3, 243);
			this.aux1Control.Name = "aux1Control";
			this.aux1Control.Size = new System.Drawing.Size(656, 54);
			this.aux1Control.TabIndex = 10;
			// 
			// rudderControl
			// 
			this.rudderControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rudderControl.Channel = BothezatConfig.Serial.MessageData.Receiver.Channel.RUDDER;
			this.rudderControl.Location = new System.Drawing.Point(3, 183);
			this.rudderControl.Name = "rudderControl";
			this.rudderControl.Size = new System.Drawing.Size(656, 54);
			this.rudderControl.TabIndex = 9;
			// 
			// elevatorControl
			// 
			this.elevatorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.elevatorControl.Channel = BothezatConfig.Serial.MessageData.Receiver.Channel.ELEVATOR;
			this.elevatorControl.Location = new System.Drawing.Point(3, 123);
			this.elevatorControl.Name = "elevatorControl";
			this.elevatorControl.Size = new System.Drawing.Size(656, 54);
			this.elevatorControl.TabIndex = 8;
			// 
			// aileronControl
			// 
			this.aileronControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aileronControl.Channel = BothezatConfig.Serial.MessageData.Receiver.Channel.AILERON;
			this.aileronControl.Location = new System.Drawing.Point(3, 63);
			this.aileronControl.Name = "aileronControl";
			this.aileronControl.Size = new System.Drawing.Size(656, 54);
			this.aileronControl.TabIndex = 7;
			// 
			// throttleControl
			// 
			this.throttleControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.throttleControl.Channel = BothezatConfig.Serial.MessageData.Receiver.Channel.THROTTLE;
			this.throttleControl.Location = new System.Drawing.Point(3, 3);
			this.throttleControl.Name = "throttleControl";
			this.throttleControl.Size = new System.Drawing.Size(656, 54);
			this.throttleControl.TabIndex = 6;
			// 
			// optionsPanel
			// 
			this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.optionsPanel.ColumnCount = 4;
			this.optionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.optionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.optionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.optionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.optionsPanel.Controls.Add(this.accelOrientationButton, 1, 0);
			this.optionsPanel.Controls.Add(this.orientationButton, 0, 0);
			this.optionsPanel.Location = new System.Drawing.Point(670, 745);
			this.optionsPanel.Name = "optionsPanel";
			this.optionsPanel.RowCount = 1;
			this.optionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.optionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.optionsPanel.Size = new System.Drawing.Size(662, 25);
			this.optionsPanel.TabIndex = 5;
			// 
			// accelOrientationButton
			// 
			this.accelOrientationButton.AutoSize = true;
			this.accelOrientationButton.Location = new System.Drawing.Point(168, 3);
			this.accelOrientationButton.Name = "accelOrientationButton";
			this.accelOrientationButton.Size = new System.Drawing.Size(115, 17);
			this.accelOrientationButton.TabIndex = 4;
			this.accelOrientationButton.Text = "Accelerometer only";
			this.accelOrientationButton.UseVisualStyleBackColor = true;
			// 
			// orientationButton
			// 
			this.orientationButton.AutoSize = true;
			this.orientationButton.Checked = true;
			this.orientationButton.Location = new System.Drawing.Point(3, 3);
			this.orientationButton.Name = "orientationButton";
			this.orientationButton.Size = new System.Drawing.Size(72, 17);
			this.orientationButton.TabIndex = 3;
			this.orientationButton.TabStop = true;
			this.orientationButton.Text = "Combined";
			this.orientationButton.UseVisualStyleBackColor = true;
			// 
			// consoleOutputBox
			// 
			this.consoleOutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleOutputBox.Location = new System.Drawing.Point(3, 374);
			this.consoleOutputBox.Multiline = true;
			this.consoleOutputBox.Name = "consoleOutputBox";
			this.consoleOutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.consoleOutputBox.Size = new System.Drawing.Size(661, 365);
			this.consoleOutputBox.TabIndex = 0;
			// 
			// configPanel
			// 
			this.configPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.configPanel.ColumnCount = 2;
			this.configPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.configPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.configPanel.Controls.Add(label3, 0, 2);
			this.configPanel.Controls.Add(label2, 0, 1);
			this.configPanel.Controls.Add(this.yawPID, 1, 0);
			this.configPanel.Controls.Add(this.pitchPID, 1, 1);
			this.configPanel.Controls.Add(this.rollPid, 1, 2);
			this.configPanel.Controls.Add(label1, 0, 0);
			this.configPanel.Controls.Add(this.configValuePanel, 1, 3);
			this.configPanel.Location = new System.Drawing.Point(3, 3);
			this.configPanel.Name = "configPanel";
			this.configPanel.RowCount = 4;
			this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.configPanel.Size = new System.Drawing.Size(661, 365);
			this.configPanel.TabIndex = 6;
			// 
			// yawPID
			// 
			this.yawPID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.yawPID.Config = null;
			this.yawPID.Location = new System.Drawing.Point(63, 3);
			this.yawPID.Name = "yawPID";
			this.yawPID.Size = new System.Drawing.Size(595, 24);
			this.yawPID.TabIndex = 0;
			// 
			// pitchPID
			// 
			this.pitchPID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pitchPID.Config = null;
			this.pitchPID.Location = new System.Drawing.Point(63, 33);
			this.pitchPID.Name = "pitchPID";
			this.pitchPID.Size = new System.Drawing.Size(595, 24);
			this.pitchPID.TabIndex = 1;
			// 
			// rollPid
			// 
			this.rollPid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rollPid.Config = null;
			this.rollPid.Location = new System.Drawing.Point(63, 63);
			this.rollPid.Name = "rollPid";
			this.rollPid.Size = new System.Drawing.Size(595, 24);
			this.rollPid.TabIndex = 2;
			// 
			// configValuePanel
			// 
			this.configValuePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.configValuePanel.AutoScroll = true;
			this.configPanel.SetColumnSpan(this.configValuePanel, 2);
			this.configValuePanel.Location = new System.Drawing.Point(3, 93);
			this.configValuePanel.Name = "configValuePanel";
			this.configValuePanel.Size = new System.Drawing.Size(655, 269);
			this.configValuePanel.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1335, 797);
			this.Controls.Add(this.mainLayout);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Bothezat configurator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.channelTable.ResumeLayout(false);
			this.optionsPanel.ResumeLayout(false);
			this.optionsPanel.PerformLayout();
			this.configPanel.ResumeLayout(false);
			this.configPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DoubleBufferedLayoutPanel mainLayout;
        private System.Windows.Forms.TextBox consoleOutputBox;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.TableLayoutPanel channelTable;
        private System.Windows.Forms.RadioButton orientationButton;
        private System.Windows.Forms.TableLayoutPanel optionsPanel;
        private System.Windows.Forms.RadioButton accelOrientationButton;
        private System.Windows.Forms.TableLayoutPanel configPanel;
        private PIDControl yawPID;
        private PIDControl pitchPID;
        private PIDControl rollPid;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private ChannelControl throttleControl;
        private ChannelControl rudderControl;
        private ChannelControl elevatorControl;
        private ChannelControl aileronControl;
        private System.Windows.Forms.ToolStripMenuItem revertToDefaultsToolStripMenuItem;
		private System.Windows.Forms.Panel configValuePanel;
		private ChannelControl aux1Control;
		private ChannelControl aux2Control;
	}
}

