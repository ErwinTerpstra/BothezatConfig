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
            this.mainLayout.ColumnCount = 4;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.Controls.Add(this.endpointsLabel, 0, 1);
            this.mainLayout.Controls.Add(this.channelLabel, 0, 0);
            this.mainLayout.Controls.Add(this.channelBar, 1, 0);
            this.mainLayout.Controls.Add(this.minValue, 1, 1);
            this.mainLayout.Controls.Add(this.midValue, 2, 1);
            this.mainLayout.Controls.Add(this.maxValue, 3, 1);
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
            this.endpointsLabel.Location = new System.Drawing.Point(3, 35);
            this.endpointsLabel.Name = "endpointsLabel";
            this.endpointsLabel.Size = new System.Drawing.Size(57, 13);
            this.endpointsLabel.TabIndex = 5;
            this.endpointsLabel.Text = "Endpoints:";
            // 
            // channelBar
            // 
            this.channelBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayout.SetColumnSpan(this.channelBar, 3);
            this.channelBar.Location = new System.Drawing.Point(73, 3);
            this.channelBar.Name = "channelBar";
            this.channelBar.Size = new System.Drawing.Size(420, 22);
            this.channelBar.TabIndex = 1;
            // 
            // minValue
            // 
            this.minValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minValue.Location = new System.Drawing.Point(73, 32);
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
            this.minValue.Size = new System.Drawing.Size(135, 20);
            this.minValue.TabIndex = 2;
            this.minValue.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // midValue
            // 
            this.midValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.midValue.Location = new System.Drawing.Point(214, 32);
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
            this.midValue.Size = new System.Drawing.Size(135, 20);
            this.midValue.TabIndex = 3;
            this.midValue.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // maxValue
            // 
            this.maxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxValue.Location = new System.Drawing.Point(355, 32);
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
            this.maxValue.Size = new System.Drawing.Size(138, 20);
            this.maxValue.TabIndex = 4;
            this.maxValue.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
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

    }
}
