namespace RelentAttachProcess
{
    partial class frmQuestLogger
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.chProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.lblChapter = new System.Windows.Forms.Label();
            this.chkAnnoyMe = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(274, 228);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcess,
            this.chDescription,
            this.chValue,
            this.chTime});
            this.lvProcesses.HideSelection = false;
            this.lvProcesses.Location = new System.Drawing.Point(12, 12);
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(498, 197);
            this.lvProcesses.TabIndex = 1;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            // 
            // chProcess
            // 
            this.chProcess.Text = "Address";
            this.chProcess.Width = 61;
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 307;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 39;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 87;
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.TmrTime_Tick);
            // 
            // lblChapter
            // 
            this.lblChapter.AutoSize = true;
            this.lblChapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChapter.Location = new System.Drawing.Point(26, 225);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(0, 24);
            this.lblChapter.TabIndex = 2;
            // 
            // chkAnnoyMe
            // 
            this.chkAnnoyMe.AutoSize = true;
            this.chkAnnoyMe.Location = new System.Drawing.Point(188, 232);
            this.chkAnnoyMe.Name = "chkAnnoyMe";
            this.chkAnnoyMe.Size = new System.Drawing.Size(73, 17);
            this.chkAnnoyMe.TabIndex = 3;
            this.chkAnnoyMe.Text = "Annoy me";
            this.chkAnnoyMe.UseVisualStyleBackColor = true;
            // 
            // frmQuestLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 264);
            this.Controls.Add(this.chkAnnoyMe);
            this.Controls.Add(this.lblChapter);
            this.Controls.Add(this.lvProcesses);
            this.Controls.Add(this.btnStart);
            this.Name = "frmQuestLogger";
            this.Text = "Kash\'s Quest flag logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader chProcess;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.Label lblChapter;
        private System.Windows.Forms.CheckBox chkAnnoyMe;
    }
}

