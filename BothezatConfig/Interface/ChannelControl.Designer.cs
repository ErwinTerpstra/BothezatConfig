namespace BothezatConfig.Interface
{
    partial class ChannelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.channelLabel = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.endpointsLabel = new System.Windows.Forms.Label();
            this.channelBar = new System.Windows.Forms.ProgressBar();
            this.minValue = new System.Windows.Forms.NumericUpDown();
            this.midValue = new System.Windows.Forms.NumericUpDown();
            this.maxValue = new System.Windows.Forms.NumericUpDown();
            this.pulseTimeLabel = new System.Windows.Forms.Label();
            this.invertBox = new System.Windows.Forms.CheckBox();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // channelLabel
            // 
            this.channelLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.channelLabel.AutoSize = true;
            this.channelLabel.Location = new System.Drawing.Point(3, 7);
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(49, 13);
            this.channelLabel.TabIndex = 0;
            this.channelLabel.Text = "Channel:";
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 5;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.mainLayout.Controls.Add(this.endpointsLabel, 0, 1);
            this.mainLayout.Controls.Add(this.channelLabel, 0, 0);
            this.mainLayout.Controls.Add(this.channelBar, 1, 0);
            this.mainLayout.Controls.Add(this.minValue, 1, 1);
            this.mainLayout.Controls.Add(this.midValue, 2, 1);
            this.mainLayout.Controls.Add(this.maxValue, 3, 1);
            this.mainLayout.Controls.Add(this.pulseTimeLabel, 4, 0);
            this.mainLayout.Controls.Add(this.invertBox, 4, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Size = new System.Drawing.Size(496, 56);
            this.mainLayout.TabIndex = 1;
            // 
            // endpointsLabel
            // 
            this.endpointsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.endpointsLabel.AutoSize = true;
            this.endpointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endpointsLabel.Location = new System.Drawing.Point(3, 36);
            this.endpointsLabel.Name = "endpointsLabel";
            this.endpointsLabel.Size = new System.Drawing.Size(49, 12);
            this.endpointsLabel.TabIndex = 5;
            this.endpointsLabel.Text = "Endpoints:";
            // 
            // channelBar
            // 
            this.channelBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayout.SetColumnSpan(this.channelBar, 3);
            this.channelBar.Location = new System.Drawing.Point(103, 3);
            this.channelBar.Name = "channelBar";
            this.channelBar.Size = new System.Drawing.Size(306, 22);
            this.channelBar.TabIndex = 1;
            // 
            // minValue
            // 
            this.minValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minValue.Location = new System.Drawing.Point(103, 32);
            this.minValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.minValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minValue.Name = "minValue";
            this.minValue.Size = new System.Drawing.Size(98, 20);
            this.minValue.TabIndex = 2;
            this.minValue.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minValue.ValueChanged += new System.EventHandler(this.OnEndPointChanged);
            // 
            // midValue
            // 
            this.midValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.midValue.Location = new System.Drawing.Point(207, 32);
            this.midValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.midValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.midValue.Name = "midValue";
            this.midValue.Size = new System.Drawing.Size(98, 20);
            this.midValue.TabIndex = 3;
            this.midValue.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.midValue.ValueChanged += new System.EventHandler(this.OnEndPointChanged);
            // 
            // maxValue
            // 
            this.maxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxValue.Location = new System.Drawing.Point(311, 32);
            this.maxValue.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.maxValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxValue.Name = "maxValue";
            this.maxValue.Size = new System.Drawing.Size(98, 20);
            this.maxValue.TabIndex = 4;
            this.maxValue.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.maxValue.ValueChanged += new System.EventHandler(this.OnEndPointChanged);
            // 
            // pulseTimeLabel
            // 
            this.pulseTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pulseTimeLabel.AutoSize = true;
            this.pulseTimeLabel.Location = new System.Drawing.Point(415, 0);
            this.pulseTimeLabel.Name = "pulseTimeLabel";
            this.pulseTimeLabel.Size = new System.Drawing.Size(78, 28);
            this.pulseTimeLabel.TabIndex = 6;
            this.pulseTimeLabel.Text = "1500";
            this.pulseTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // invertBox
            // 
            this.invertBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.invertBox.AutoSize = true;
            this.invertBox.Location = new System.Drawing.Point(415, 33);
            this.invertBox.Name = "invertBox";
            this.invertBox.Size = new System.Drawing.Size(53, 17);
            this.invertBox.TabIndex = 7;
            this.invertBox.Text = "Invert";
            this.invertBox.UseVisualStyleBackColor = true;
            // 
            // ChannelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayout);
            this.Name = "ChannelControl";
            this.Size = new System.Drawing.Size(496, 56);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label channelLabel;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.ProgressBar channelBar;
        private System.Windows.Forms.NumericUpDown minValue;
        private System.Windows.Forms.NumericUpDown midValue;
        private System.Windows.Forms.NumericUpDown maxValue;
        private System.Windows.Forms.Label endpointsLabel;
        private System.Windows.Forms.Label pulseTimeLabel;
        private System.Windows.Forms.CheckBox invertBox;

    }
}
