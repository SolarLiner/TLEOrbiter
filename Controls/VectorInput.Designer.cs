namespace TLEOrbiter.Controls
{
    partial class VectorInput
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
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.NUD_X = new System.Windows.Forms.NumericUpDown();
            this.NUD_Y = new System.Windows.Forms.NumericUpDown();
            this.NUD_Z = new System.Windows.Forms.NumericUpDown();
            this.LB_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Z)).BeginInit();
            this.SuspendLayout();
            // 
            // NUD_X
            // 
            this.NUD_X.DecimalPlaces = 2;
            this.NUD_X.Location = new System.Drawing.Point(202, 3);
            this.NUD_X.Name = "NUD_X";
            this.NUD_X.Size = new System.Drawing.Size(80, 20);
            this.NUD_X.TabIndex = 0;
            this.NUD_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NUD_Y
            // 
            this.NUD_Y.DecimalPlaces = 2;
            this.NUD_Y.Location = new System.Drawing.Point(288, 3);
            this.NUD_Y.Name = "NUD_Y";
            this.NUD_Y.Size = new System.Drawing.Size(80, 20);
            this.NUD_Y.TabIndex = 1;
            this.NUD_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NUD_Z
            // 
            this.NUD_Z.DecimalPlaces = 2;
            this.NUD_Z.Location = new System.Drawing.Point(374, 3);
            this.NUD_Z.Name = "NUD_Z";
            this.NUD_Z.Size = new System.Drawing.Size(80, 20);
            this.NUD_Z.TabIndex = 2;
            this.NUD_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LB_Name
            // 
            this.LB_Name.AutoSize = true;
            this.LB_Name.Location = new System.Drawing.Point(3, 5);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(41, 13);
            this.LB_Name.TabIndex = 3;
            this.LB_Name.Text = "Name: ";
            // 
            // VectorInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LB_Name);
            this.Controls.Add(this.NUD_X);
            this.Controls.Add(this.NUD_Y);
            this.Controls.Add(this.NUD_Z);
            this.Name = "VectorInput";
            this.Size = new System.Drawing.Size(457, 27);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Z)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NUD_X;
        private System.Windows.Forms.NumericUpDown NUD_Y;
        private System.Windows.Forms.NumericUpDown NUD_Z;
        private System.Windows.Forms.Label LB_Name;
    }
}
