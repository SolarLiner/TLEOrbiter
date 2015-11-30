namespace TLEOrbiter
{
    partial class DateChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateChange));
            this.MC_Calendar = new System.Windows.Forms.MonthCalendar();
            this.NU_Hours = new System.Windows.Forms.NumericUpDown();
            this.NU_Minutes = new System.Windows.Forms.NumericUpDown();
            this.NU_Seconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_OK = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NU_MJD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NU_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NU_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NU_Seconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NU_MJD)).BeginInit();
            this.SuspendLayout();
            // 
            // MC_Calendar
            // 
            resources.ApplyResources(this.MC_Calendar, "MC_Calendar");
            this.MC_Calendar.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.MC_Calendar.MinDate = new System.DateTime(1858, 11, 17, 0, 0, 0, 0);
            this.MC_Calendar.Name = "MC_Calendar";
            this.MC_Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MC_Calendar_DateChanged);
            // 
            // NU_Hours
            // 
            resources.ApplyResources(this.NU_Hours, "NU_Hours");
            this.NU_Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.NU_Hours.Name = "NU_Hours";
            this.NU_Hours.ValueChanged += new System.EventHandler(this.NU_ValueChanged);
            // 
            // NU_Minutes
            // 
            resources.ApplyResources(this.NU_Minutes, "NU_Minutes");
            this.NU_Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NU_Minutes.Name = "NU_Minutes";
            this.NU_Minutes.ValueChanged += new System.EventHandler(this.NU_ValueChanged);
            // 
            // NU_Seconds
            // 
            resources.ApplyResources(this.NU_Seconds, "NU_Seconds");
            this.NU_Seconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NU_Seconds.Name = "NU_Seconds";
            this.NU_Seconds.ValueChanged += new System.EventHandler(this.NU_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // BT_OK
            // 
            resources.ApplyResources(this.BT_OK, "BT_OK");
            this.BT_OK.Name = "BT_OK";
            this.BT_OK.UseVisualStyleBackColor = true;
            this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BT_Cancel, "BT_Cancel");
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // NU_MJD
            // 
            this.NU_MJD.DecimalPlaces = 5;
            resources.ApplyResources(this.NU_MJD, "NU_MJD");
            this.NU_MJD.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            327680});
            this.NU_MJD.Name = "NU_MJD";
            this.NU_MJD.ValueChanged += new System.EventHandler(this.NU_MJD_ValueChanged);
            // 
            // DateChange
            // 
            this.AcceptButton = this.BT_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.BT_Cancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NU_MJD);
            this.Controls.Add(this.NU_Seconds);
            this.Controls.Add(this.NU_Minutes);
            this.Controls.Add(this.NU_Hours);
            this.Controls.Add(this.MC_Calendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateChange";
            ((System.ComponentModel.ISupportInitialize)(this.NU_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NU_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NU_Seconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NU_MJD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar MC_Calendar;
        private System.Windows.Forms.NumericUpDown NU_Hours;
        private System.Windows.Forms.NumericUpDown NU_Minutes;
        private System.Windows.Forms.NumericUpDown NU_Seconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NU_MJD;
    }
}