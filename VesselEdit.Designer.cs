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
            if( disposing && (components != null) )
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
            this.LB_TLEName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_VesselName = new System.Windows.Forms.ComboBox();
            this.GB_VesselData = new System.Windows.Forms.GroupBox();
            this.BT_OK = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.TB_TLEData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_VesselName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LB_TLEName
            // 
            resources.ApplyResources(this.LB_TLEName, "LB_TLEName");
            this.LB_TLEName.Name = "LB_TLEName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CB_VesselName
            // 
            resources.ApplyResources(this.CB_VesselName, "CB_VesselName");
            this.CB_VesselName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_VesselName.FormattingEnabled = true;
            this.CB_VesselName.Name = "CB_VesselName";
            this.CB_VesselName.Sorted = true;
            this.CB_VesselName.SelectionChangeCommitted += new System.EventHandler(this.CB_VesselName_SelectionChangeCommitted);
            // 
            // GB_VesselData
            // 
            resources.ApplyResources(this.GB_VesselData, "GB_VesselData");
            this.GB_VesselData.Name = "GB_VesselData";
            this.GB_VesselData.TabStop = false;
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
            resources.ApplyResources(this.BT_Cancel, "BT_Cancel");
            this.BT_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            // 
            // TB_TLEData
            // 
            resources.ApplyResources(this.TB_TLEData, "TB_TLEData");
            this.TB_TLEData.Name = "TB_TLEData";
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
            // TB_VesselName
            // 
            resources.ApplyResources(this.TB_VesselName, "TB_VesselName");
            this.TB_VesselName.Name = "TB_VesselName";
            // 
            // VesselEdit
            // 
            this.AcceptButton = this.BT_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancel;
            this.Controls.Add(this.TB_VesselName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_TLEData);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.GB_VesselData);
            this.Controls.Add(this.CB_VesselName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_TLEName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VesselEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.VesselEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_TLEName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_VesselName;
        private System.Windows.Forms.GroupBox GB_VesselData;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.TextBox TB_TLEData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_VesselName;
    }
}