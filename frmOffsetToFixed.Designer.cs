namespace RelentAttachProcess
{
    partial class frmOffsetToFixed
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
            this.lvOffsetToFixed = new System.Windows.Forms.ListView();
            this.chDOSBoxBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRelent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDifference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvOffsetToFixed
            // 
            this.lvOffsetToFixed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDOSBoxBase,
            this.chRelent,
            this.chDifference});
            this.lvOffsetToFixed.Location = new System.Drawing.Point(12, 27);
            this.lvOffsetToFixed.Name = "lvOffsetToFixed";
            this.lvOffsetToFixed.Size = new System.Drawing.Size(320, 204);
            this.lvOffsetToFixed.TabIndex = 0;
            this.lvOffsetToFixed.UseCompatibleStateImageBehavior = false;
            this.lvOffsetToFixed.View = System.Windows.Forms.View.Details;
            // 
            // chDOSBoxBase
            // 
            this.chDOSBoxBase.Text = "DOSBox Base";
            this.chDOSBoxBase.Width = 98;
            // 
            // chRelent
            // 
            this.chRelent.Text = "Relent Addr";
            this.chRelent.Width = 95;
            // 
            // chDifference
            // 
            this.chDifference.Text = "Difference";
            this.chDifference.Width = 119;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(136, 237);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // frmOffsetToFixed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 272);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lvOffsetToFixed);
            this.Name = "frmOffsetToFixed";
            this.Text = "frmOffsetToFixed";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvOffsetToFixed;
        private System.Windows.Forms.ColumnHeader chDOSBoxBase;
        private System.Windows.Forms.ColumnHeader chRelent;
        private System.Windows.Forms.ColumnHeader chDifference;
        private System.Windows.Forms.Button btnScan;
    }
}