namespace TLEOrbiter
{
    partial class ImportTLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportTLE));
            this.label1 = new System.Windows.Forms.Label();
            this.TB_TleUrl = new System.Windows.Forms.TextBox();
            this.BT_OK = new System.Windows.Forms.Button();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.EP_Validator = new System.Windows.Forms.ErrorProvider(this.components);
            this.BT_BrowseLocalFile = new System.Windows.Forms.Button();
            this.toolTipBrowseLocalFile = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EP_Validator)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TB_TleUrl
            // 
            resources.ApplyResources(this.TB_TleUrl, "TB_TleUrl");
            this.TB_TleUrl.Name = "TB_TleUrl";
            this.TB_TleUrl.TextChanged += new System.EventHandler(this.TB_TleUrl_TextChanged);
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
            // 
            // EP_Validator
            // 
            this.EP_Validator.ContainerControl = this;
            // 
            // BT_BrowseLocalFile
            // 
            resources.ApplyResources(this.BT_BrowseLocalFile, "BT_BrowseLocalFile");
            this.BT_BrowseLocalFile.Name = "BT_BrowseLocalFile";
            this.toolTipBrowseLocalFile.SetToolTip(this.BT_BrowseLocalFile, resources.GetString("BT_BrowseLocalFile.ToolTip"));
            this.BT_BrowseLocalFile.UseVisualStyleBackColor = true;
            this.BT_BrowseLocalFile.Click += new System.EventHandler(this.BT_BrowseLocalFile_Click);
            // 
            // ImportTLE
            // 
            this.AcceptButton = this.BT_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_Cancel;
            this.Controls.Add(this.BT_BrowseLocalFile);
            this.Controls.Add(this.BT_Cancel);
            this.Controls.Add(this.BT_OK);
            this.Controls.Add(this.TB_TleUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportTLE";
            ((System.ComponentModel.ISupportInitialize)(this.EP_Validator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_TleUrl;
        private System.Windows.Forms.Button BT_OK;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.ErrorProvider EP_Validator;
        private System.Windows.Forms.Button BT_BrowseLocalFile;
        private System.Windows.Forms.ToolTip toolTipBrowseLocalFile;
    }
}