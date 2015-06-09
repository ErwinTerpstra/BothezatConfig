namespace BothezatConfig.Interface
{
    partial class PIDControl
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
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.dField = new System.Windows.Forms.NumericUpDown();
            this.iField = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pField = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.mainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pField)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 6;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.mainTable.Controls.Add(this.dField, 5, 0);
            this.mainTable.Controls.Add(this.iField, 3, 0);
            this.mainTable.Controls.Add(this.label2, 2, 0);
            this.mainTable.Controls.Add(this.label1, 0, 0);
            this.mainTable.Controls.Add(this.pField, 1, 0);
            this.mainTable.Controls.Add(this.label3, 4, 0);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 1;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTable.Size = new System.Drawing.Size(454, 30);
            this.mainTable.TabIndex = 0;
            // 
            // dField
            // 
            this.dField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dField.DecimalPlaces = 3;
            this.dField.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dField.Location = new System.Drawing.Point(335, 5);
            this.dField.Name = "dField";
            this.dField.Size = new System.Drawing.Size(116, 20);
            this.dField.TabIndex = 5;
            this.dField.ValueChanged += new System.EventHandler(this.field_ValueChanged);
            // 
            // iField
            // 
            this.iField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.iField.DecimalPlaces = 3;
            this.iField.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.iField.Location = new System.Drawing.Point(184, 5);
            this.iField.Name = "iField";
            this.iField.Size = new System.Drawing.Size(115, 20);
            this.iField.TabIndex = 4;
            this.iField.ValueChanged += new System.EventHandler(this.field_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "I:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "P:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pField
            // 
            this.pField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pField.DecimalPlaces = 3;
            this.pField.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.pField.Location = new System.Drawing.Point(33, 5);
            this.pField.Name = "pField";
            this.pField.Size = new System.Drawing.Size(115, 20);
            this.pField.TabIndex = 1;
            this.pField.ValueChanged += new System.EventHandler(this.field_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "D:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PIDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTable);
            this.Name = "PIDControl";
            this.Size = new System.Drawing.Size(454, 30);
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown iField;
        private System.Windows.Forms.NumericUpDown dField;
    }
}
