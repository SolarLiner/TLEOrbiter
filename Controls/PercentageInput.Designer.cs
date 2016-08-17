namespace TLEOrbiter.Controls
{
    partial class PercentageInput
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
            this.NUD_Value = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // NUD_Value
            // 
            this.NUD_Value.DecimalPlaces = 2;
            this.NUD_Value.Location = new System.Drawing.Point(220, 3);
            this.NUD_Value.Name = "NUD_Value";
            this.NUD_Value.Size = new System.Drawing.Size(214, 20);
            this.NUD_Value.TabIndex = 0;
            this.NUD_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            // 
            // LB_Name
            // 
            this.LB_Name.AutoSize = true;
            this.LB_Name.Location = new System.Drawing.Point(3, 5);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(41, 13);
            this.LB_Name.TabIndex = 2;
            this.LB_Name.Text = "Name: ";
            // 
            // PercentageInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LB_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NUD_Value);
            this.Name = "PercentageInput";
            this.Size = new System.Drawing.Size(457, 27);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NUD_Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Name;
    }
}
