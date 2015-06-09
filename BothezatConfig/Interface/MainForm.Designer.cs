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
            this.revertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new BothezatConfig.Interface.DoubleBufferedLayoutPanel(this.components);
            this.glControl = new OpenTK.GLControl();
            this.channelTable = new System.Windows.Forms.TableLayoutPanel();
            this.rudderLabel = new System.Windows.Forms.Label();
            this.aileronLabel = new System.Windows.Forms.Label();
            this.elevatorLabel = new System.Windows.Forms.Label();
            this.rudderBar = new System.Windows.Forms.ProgressBar();
            this.aileronBar = new System.Windows.Forms.ProgressBar();
            this.throttleBar = new System.Windows.Forms.ProgressBar();
            this.elevatorBar = new System.Windows.Forms.ProgressBar();
            this.throttleLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.accelOrientationButton = new System.Windows.Forms.RadioButton();
            this.orientationButton = new System.Windows.Forms.RadioButton();
            this.consoleOutputBox = new System.Windows.Forms.TextBox();
            this.configPanel = new System.Windows.Forms.TableLayoutPanel();
            this.yawPID = new BothezatConfig.Interface.PIDControl();
            this.pitchPID = new BothezatConfig.Interface.PIDControl();
            this.rollPid = new BothezatConfig.Interface.PIDControl();
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
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1177, 24);
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
            this.revertToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "&Config";
            // 
            // revertToolStripMenuItem
            // 
            this.revertToolStripMenuItem.Name = "revertToolStripMenuItem";
            this.revertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.revertToolStripMenuItem.Text = "&Revert";
            this.revertToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.Size = new System.Drawing.Size(1177, 670);
            this.mainLayout.TabIndex = 1;
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(591, 313);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(583, 304);
            this.glControl.TabIndex = 1;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // channelTable
            // 
            this.channelTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelTable.ColumnCount = 2;
            this.channelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.channelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.channelTable.Controls.Add(this.rudderLabel, 0, 3);
            this.channelTable.Controls.Add(this.aileronLabel, 0, 2);
            this.channelTable.Controls.Add(this.elevatorLabel, 0, 1);
            this.channelTable.Controls.Add(this.rudderBar, 1, 3);
            this.channelTable.Controls.Add(this.aileronBar, 1, 2);
            this.channelTable.Controls.Add(this.throttleBar, 1, 0);
            this.channelTable.Controls.Add(this.elevatorBar, 1, 1);
            this.channelTable.Controls.Add(this.throttleLabel, 0, 0);
            this.channelTable.Location = new System.Drawing.Point(591, 3);
            this.channelTable.Name = "channelTable";
            this.channelTable.RowCount = 4;
            this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.channelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.channelTable.Size = new System.Drawing.Size(583, 78);
            this.channelTable.TabIndex = 2;
            // 
            // rudderLabel
            // 
            this.rudderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rudderLabel.AutoSize = true;
            this.rudderLabel.Location = new System.Drawing.Point(3, 60);
            this.rudderLabel.Name = "rudderLabel";
            this.rudderLabel.Size = new System.Drawing.Size(42, 20);
            this.rudderLabel.TabIndex = 7;
            this.rudderLabel.Text = "Rudder";
            this.rudderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aileronLabel
            // 
            this.aileronLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aileronLabel.AutoSize = true;
            this.aileronLabel.Location = new System.Drawing.Point(3, 40);
            this.aileronLabel.Name = "aileronLabel";
            this.aileronLabel.Size = new System.Drawing.Size(39, 20);
            this.aileronLabel.TabIndex = 6;
            this.aileronLabel.Text = "Aileron";
            this.aileronLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // elevatorLabel
            // 
            this.elevatorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.elevatorLabel.AutoSize = true;
            this.elevatorLabel.Location = new System.Drawing.Point(3, 20);
            this.elevatorLabel.Name = "elevatorLabel";
            this.elevatorLabel.Size = new System.Drawing.Size(49, 20);
            this.elevatorLabel.TabIndex = 5;
            this.elevatorLabel.Text = "Elevator:";
            this.elevatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rudderBar
            // 
            this.rudderBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rudderBar.Location = new System.Drawing.Point(103, 63);
            this.rudderBar.MarqueeAnimationSpeed = 0;
            this.rudderBar.Name = "rudderBar";
            this.rudderBar.Size = new System.Drawing.Size(477, 14);
            this.rudderBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.rudderBar.TabIndex = 3;
            // 
            // aileronBar
            // 
            this.aileronBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aileronBar.Location = new System.Drawing.Point(103, 43);
            this.aileronBar.MarqueeAnimationSpeed = 0;
            this.aileronBar.Name = "aileronBar";
            this.aileronBar.Size = new System.Drawing.Size(477, 14);
            this.aileronBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.aileronBar.TabIndex = 3;
            // 
            // throttleBar
            // 
            this.throttleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.throttleBar.Location = new System.Drawing.Point(103, 3);
            this.throttleBar.MarqueeAnimationSpeed = 0;
            this.throttleBar.Name = "throttleBar";
            this.throttleBar.Size = new System.Drawing.Size(477, 14);
            this.throttleBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.throttleBar.TabIndex = 0;
            // 
            // elevatorBar
            // 
            this.elevatorBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevatorBar.Location = new System.Drawing.Point(103, 23);
            this.elevatorBar.MarqueeAnimationSpeed = 0;
            this.elevatorBar.Name = "elevatorBar";
            this.elevatorBar.Size = new System.Drawing.Size(477, 14);
            this.elevatorBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.elevatorBar.TabIndex = 1;
            // 
            // throttleLabel
            // 
            this.throttleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.throttleLabel.AutoSize = true;
            this.throttleLabel.Location = new System.Drawing.Point(3, 0);
            this.throttleLabel.Name = "throttleLabel";
            this.throttleLabel.Size = new System.Drawing.Size(46, 20);
            this.throttleLabel.TabIndex = 4;
            this.throttleLabel.Text = "Throttle:";
            this.throttleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.optionsPanel.Location = new System.Drawing.Point(591, 623);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.RowCount = 1;
            this.optionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.optionsPanel.Size = new System.Drawing.Size(583, 44);
            this.optionsPanel.TabIndex = 5;
            // 
            // accelOrientationButton
            // 
            this.accelOrientationButton.AutoSize = true;
            this.accelOrientationButton.Location = new System.Drawing.Point(148, 3);
            this.accelOrientationButton.Name = "accelOrientationButton";
            this.accelOrientationButton.Size = new System.Drawing.Size(115, 17);
            this.accelOrientationButton.TabIndex = 4;
            this.accelOrientationButton.TabStop = true;
            this.accelOrientationButton.Text = "Accelerometer only";
            this.accelOrientationButton.UseVisualStyleBackColor = true;
            // 
            // orientationButton
            // 
            this.orientationButton.AutoSize = true;
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
            this.consoleOutputBox.Location = new System.Drawing.Point(3, 313);
            this.consoleOutputBox.Multiline = true;
            this.consoleOutputBox.Name = "consoleOutputBox";
            this.consoleOutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleOutputBox.Size = new System.Drawing.Size(582, 304);
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
            this.configPanel.Location = new System.Drawing.Point(3, 3);
            this.configPanel.Name = "configPanel";
            this.configPanel.RowCount = 4;
            this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.configPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.configPanel.Size = new System.Drawing.Size(582, 304);
            this.configPanel.TabIndex = 6;
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
            // yawPID
            // 
            this.yawPID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yawPID.Config = null;
            this.yawPID.Location = new System.Drawing.Point(63, 3);
            this.yawPID.Name = "yawPID";
            this.yawPID.Size = new System.Drawing.Size(516, 24);
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
            this.pitchPID.Size = new System.Drawing.Size(516, 24);
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
            this.rollPid.Size = new System.Drawing.Size(516, 24);
            this.rollPid.TabIndex = 2;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 694);
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
            this.channelTable.PerformLayout();
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
        private System.Windows.Forms.ProgressBar rudderBar;
        private System.Windows.Forms.ProgressBar aileronBar;
        private System.Windows.Forms.ProgressBar throttleBar;
        private System.Windows.Forms.ProgressBar elevatorBar;
        private System.Windows.Forms.Label rudderLabel;
        private System.Windows.Forms.Label aileronLabel;
        private System.Windows.Forms.Label elevatorLabel;
        private System.Windows.Forms.Label throttleLabel;
        private System.Windows.Forms.RadioButton orientationButton;
        private System.Windows.Forms.TableLayoutPanel optionsPanel;
        private System.Windows.Forms.RadioButton accelOrientationButton;
        private System.Windows.Forms.TableLayoutPanel configPanel;
        private PIDControl yawPID;
        private PIDControl pitchPID;
        private PIDControl rollPid;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

