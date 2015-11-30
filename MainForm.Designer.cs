namespace TLEOrbiter
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BT_EditScenario = new System.Windows.Forms.Button();
            this.LV_Ships = new System.Windows.Forms.ListView();
            this.TLEName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrbiterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VesselClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BT_GenScn = new System.Windows.Forms.Button();
            this.BT_ImportTLE = new System.Windows.Forms.Button();
            this.BT_SelectNone = new System.Windows.Forms.Button();
            this.BT_SelectAll = new System.Windows.Forms.Button();
            this.BT_InvertSelection = new System.Windows.Forms.Button();
            this.LL_Settings = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BT_EditScenario
            // 
            resources.ApplyResources(this.BT_EditScenario, "BT_EditScenario");
            this.BT_EditScenario.Name = "BT_EditScenario";
            this.BT_EditScenario.UseVisualStyleBackColor = true;
            this.BT_EditScenario.Click += new System.EventHandler(this.BT_EditScenario_Click);
            // 
            // LV_Ships
            // 
            resources.ApplyResources(this.LV_Ships, "LV_Ships");
            this.LV_Ships.CheckBoxes = true;
            this.LV_Ships.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TLEName,
            this.OrbiterName,
            this.VesselClass});
            this.LV_Ships.FullRowSelect = true;
            this.LV_Ships.GridLines = true;
            this.LV_Ships.Name = "LV_Ships";
            this.LV_Ships.UseCompatibleStateImageBehavior = false;
            this.LV_Ships.View = System.Windows.Forms.View.Details;
            this.LV_Ships.DoubleClick += new System.EventHandler(this.LV_Ships_DoubleClick);
            // 
            // TLEName
            // 
            resources.ApplyResources(this.TLEName, "TLEName");
            // 
            // OrbiterName
            // 
            resources.ApplyResources(this.OrbiterName, "OrbiterName");
            // 
            // VesselClass
            // 
            resources.ApplyResources(this.VesselClass, "VesselClass");
            // 
            // BT_GenScn
            // 
            resources.ApplyResources(this.BT_GenScn, "BT_GenScn");
            this.BT_GenScn.Name = "BT_GenScn";
            this.BT_GenScn.UseVisualStyleBackColor = true;
            this.BT_GenScn.Click += new System.EventHandler(this.BT_GenScn_Click);
            // 
            // BT_ImportTLE
            // 
            resources.ApplyResources(this.BT_ImportTLE, "BT_ImportTLE");
            this.BT_ImportTLE.Name = "BT_ImportTLE";
            this.BT_ImportTLE.UseVisualStyleBackColor = true;
            this.BT_ImportTLE.Click += new System.EventHandler(this.BT_ImportTLE_Click);
            // 
            // BT_SelectNone
            // 
            resources.ApplyResources(this.BT_SelectNone, "BT_SelectNone");
            this.BT_SelectNone.Name = "BT_SelectNone";
            this.BT_SelectNone.UseVisualStyleBackColor = true;
            this.BT_SelectNone.Click += new System.EventHandler(this.BT_SelectNone_Click);
            // 
            // BT_SelectAll
            // 
            resources.ApplyResources(this.BT_SelectAll, "BT_SelectAll");
            this.BT_SelectAll.Name = "BT_SelectAll";
            this.BT_SelectAll.UseVisualStyleBackColor = true;
            this.BT_SelectAll.Click += new System.EventHandler(this.BT_SelectAll_Click);
            // 
            // BT_InvertSelection
            // 
            resources.ApplyResources(this.BT_InvertSelection, "BT_InvertSelection");
            this.BT_InvertSelection.Name = "BT_InvertSelection";
            this.BT_InvertSelection.UseVisualStyleBackColor = true;
            this.BT_InvertSelection.Click += new System.EventHandler(this.BT_InvertSelection_Click);
            // 
            // LL_Settings
            // 
            resources.ApplyResources(this.LL_Settings, "LL_Settings");
            this.LL_Settings.Name = "LL_Settings";
            this.LL_Settings.TabStop = true;
            this.LL_Settings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Settings_LinkClicked);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LL_Settings);
            this.Controls.Add(this.BT_InvertSelection);
            this.Controls.Add(this.BT_SelectAll);
            this.Controls.Add(this.BT_SelectNone);
            this.Controls.Add(this.BT_ImportTLE);
            this.Controls.Add(this.BT_GenScn);
            this.Controls.Add(this.LV_Ships);
            this.Controls.Add(this.BT_EditScenario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_EditScenario;
        private System.Windows.Forms.ListView LV_Ships;
        private System.Windows.Forms.ColumnHeader TLEName;
        private System.Windows.Forms.ColumnHeader OrbiterName;
        private System.Windows.Forms.ColumnHeader VesselClass;
        private System.Windows.Forms.Button BT_GenScn;
        private System.Windows.Forms.Button BT_ImportTLE;
        private System.Windows.Forms.Button BT_SelectNone;
        private System.Windows.Forms.Button BT_SelectAll;
        private System.Windows.Forms.Button BT_InvertSelection;
        private System.Windows.Forms.LinkLabel LL_Settings;
    }
}

