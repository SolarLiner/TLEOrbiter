namespace TLEOrbiter
{
    partial class ScenarioProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenarioProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_ScnName = new System.Windows.Forms.TextBox();
            this.RTB_ScnDesc = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BT_ChangeDate = new System.Windows.Forms.Button();
            this.CB_UseSysTime = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ER_Verifier = new System.Windows.Forms.ErrorProvider(this.components);
            this.BT_OK = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ER_Verifier)).BeginInit();
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
            // TB_ScnName
            // 
            resources.ApplyResources(this.TB_ScnName, "TB_ScnName");
            this.TB_ScnName.Name = "TB_ScnName";
            this.TB_ScnName.TextChanged += new System.EventHandler(this.TB_ScnName_TextChanged);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.RTB_ScnDesc, "richTextBox1");
            this.RTB_ScnDesc.Name = "richTextBox1";
            this.RTB_ScnDesc.TextChanged += new System.EventHandler(this.RTB_ScnDesc_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BT_ChangeDate);
            this.groupBox1.Controls.Add(this.CB_UseSysTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RTB_ScnDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_ScnName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // BT_ChangeDate
            // 
            this.BT_ChangeDate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BT_ChangeDate, "BT_ChangeDate");
            this.BT_ChangeDate.Name = "BT_ChangeDate";
            this.BT_ChangeDate.UseVisualStyleBackColor = true;
            this.BT_ChangeDate.Click += new System.EventHandler(this.BT_ChangeDate_Click);
            // 
            // CB_UseSysTime
            // 
            resources.ApplyResources(this.CB_UseSysTime, "CB_UseSysTime");
            this.CB_UseSysTime.Name = "CB_UseSysTime";
            this.CB_UseSysTime.UseVisualStyleBackColor = true;
            this.CB_UseSysTime.CheckedChanged += new System.EventHandler(this.CB_UseSysTime_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ER_Verifier
            // 
            this.ER_Verifier.ContainerControl = this;
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
            // ScenarioProperties
            // 
            this.AcceptButton = this.BT_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancel;
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScenarioProperties";
            this.Load += new System.EventHandler(this.ScenarioProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ER_Verifier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_ScnName;
        private System.Windows.Forms.RichTextBox RTB_ScnDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BT_ChangeDate;
        private System.Windows.Forms.CheckBox CB_UseSysTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider ER_Verifier;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_Cancel;
    }
}