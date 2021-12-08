
namespace CPCS
{
    partial class Calendrier_CPCS
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.jour_comboBox = new System.Windows.Forms.ComboBox();
            this.mois_comboBox = new System.Windows.Forms.ComboBox();
            this.annee_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jour_comboBox
            // 
            this.jour_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jour_comboBox.FormattingEnabled = true;
            this.jour_comboBox.Location = new System.Drawing.Point(7, 7);
            this.jour_comboBox.Name = "jour_comboBox";
            this.jour_comboBox.Size = new System.Drawing.Size(60, 28);
            this.jour_comboBox.TabIndex = 0;
            // 
            // mois_comboBox
            // 
            this.mois_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mois_comboBox.FormattingEnabled = true;
            this.mois_comboBox.Location = new System.Drawing.Point(128, 7);
            this.mois_comboBox.Name = "mois_comboBox";
            this.mois_comboBox.Size = new System.Drawing.Size(61, 28);
            this.mois_comboBox.TabIndex = 1;
            this.mois_comboBox.SelectedIndexChanged += new System.EventHandler(this.actualisationJour);
            // 
            // annee_comboBox
            // 
            this.annee_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annee_comboBox.FormattingEnabled = true;
            this.annee_comboBox.Location = new System.Drawing.Point(262, 7);
            this.annee_comboBox.Name = "annee_comboBox";
            this.annee_comboBox.Size = new System.Drawing.Size(94, 28);
            this.annee_comboBox.TabIndex = 2;
            this.annee_comboBox.SelectedIndexChanged += new System.EventHandler(this.actualisationJour);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "/";
            // 
            // Calendrier_CPCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.annee_comboBox);
            this.Controls.Add(this.mois_comboBox);
            this.Controls.Add(this.jour_comboBox);
            this.Name = "Calendrier_CPCS";
            this.Size = new System.Drawing.Size(366, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox jour_comboBox;
        private System.Windows.Forms.ComboBox mois_comboBox;
        private System.Windows.Forms.ComboBox annee_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
