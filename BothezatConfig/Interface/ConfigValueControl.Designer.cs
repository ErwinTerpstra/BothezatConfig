namespace BothezatConfig.Interface
{
    partial class ConfigValueControl
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
			this.valueBox = new System.Windows.Forms.TextBox();
			this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
			this.nameLabel = new System.Windows.Forms.Label();
			this.mainLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// valueBox
			// 
			this.valueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.valueBox.Location = new System.Drawing.Point(286, 3);
			this.valueBox.Name = "valueBox";
			this.valueBox.Size = new System.Drawing.Size(277, 20);
			this.valueBox.TabIndex = 0;
			this.valueBox.TextChanged += new System.EventHandler(this.valueBox_TextChanged);
			// 
			// mainLayout
			// 
			this.mainLayout.ColumnCount = 2;
			this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainLayout.Controls.Add(this.valueBox, 1, 0);
			this.mainLayout.Controls.Add(this.nameLabel, 0, 0);
			this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.RowCount = 1;
			this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainLayout.Size = new System.Drawing.Size(566, 26);
			this.mainLayout.TabIndex = 1;
			// 
			// nameLabel
			// 
			this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(3, 6);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(66, 13);
			this.nameLabel.TabIndex = 1;
			this.nameLabel.Text = "Value name:";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConfigValueControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mainLayout);
			this.Name = "ConfigValueControl";
			this.Size = new System.Drawing.Size(566, 26);
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TextBox valueBox;
		private System.Windows.Forms.TableLayoutPanel mainLayout;
		private System.Windows.Forms.Label nameLabel;
	}
}
