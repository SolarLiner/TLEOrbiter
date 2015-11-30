namespace TLEOrbiter
{
    partial class VesselEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VesselEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_TleName = new System.Windows.Forms.TextBox();
            this.TB_OrbiterName = new System.Windows.Forms.TextBox();
            this.TB_TLE = new System.Windows.Forms.TextBox();
            this.CB_VesselClass = new System.Windows.Forms.ComboBox();
            this.BT_OK = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.GB_VesselData = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TB_TleName
            // 
            resources.ApplyResources(this.TB_TleName, "TB_TleName");
            this.TB_TleName.Name = "TB_TleName";
            // 
            // TB_OrbiterName
            // 
            resources.ApplyResources(this.TB_OrbiterName, "TB_OrbiterName");
            this.TB_OrbiterName.Name = "TB_OrbiterName";
            // 
            // TB_TLE
            // 
            resources.ApplyResources(this.TB_TLE, "TB_TLE");
            this.TB_TLE.Name = "TB_TLE";
            // 
            // CB_VesselClass
            // 
            this.CB_VesselClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_VesselClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_VesselClass.FormattingEnabled = true;
            resources.ApplyResources(this.CB_VesselClass, "CB_VesselClass");
            this.CB_VesselClass.Name = "CB_VesselClass";
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
            // GB_VesselData
            // 
            resources.ApplyResources(this.GB_VesselData, "GB_VesselData");
            this.GB_VesselData.Name = "GB_VesselData";
            this.GB_VesselData.TabStop = false;
            // 
            // VesselEdit
            // 
            this.AcceptButton = this.BT_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancel;
            this.Controls.Add(this.GB_VesselData);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.CB_VesselClass);
            this.Controls.Add(this.TB_TLE);
            this.Controls.Add(this.TB_OrbiterName);
            this.Controls.Add(this.TB_TleName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VesselEdit";
            this.Load += new System.EventHandler(this.VesselEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_TleName;
        private System.Windows.Forms.TextBox TB_OrbiterName;
        private System.Windows.Forms.TextBox TB_TLE;
        private System.Windows.Forms.ComboBox CB_VesselClass;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.GroupBox GB_VesselData;
    }
}