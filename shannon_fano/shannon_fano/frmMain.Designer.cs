﻿namespace shannon_fano
{
    partial class frmMain
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
            this.btnChoisirSource = new System.Windows.Forms.Button();
            this.btnDecoder = new System.Windows.Forms.Button();
            this.btnEncoder = new System.Windows.Forms.Button();
            this.btnChoisirDestination = new System.Windows.Forms.Button();
            this.tbxAffichage = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEntropie = new System.Windows.Forms.Label();
            this.lblRedondance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBitsAvant = new System.Windows.Forms.Label();
            this.lblBitsApres = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChoisirSource
            // 
            this.btnChoisirSource.Location = new System.Drawing.Point(21, 96);
            this.btnChoisirSource.Name = "btnChoisirSource";
            this.btnChoisirSource.Size = new System.Drawing.Size(75, 23);
            this.btnChoisirSource.TabIndex = 0;
            this.btnChoisirSource.Text = "Choisir";
            this.btnChoisirSource.UseVisualStyleBackColor = true;
            // 
            // btnDecoder
            // 
            this.btnDecoder.Location = new System.Drawing.Point(203, 284);
            this.btnDecoder.Name = "btnDecoder";
            this.btnDecoder.Size = new System.Drawing.Size(75, 23);
            this.btnDecoder.TabIndex = 1;
            this.btnDecoder.Text = "Decoder";
            this.btnDecoder.UseVisualStyleBackColor = true;
            // 
            // btnEncoder
            // 
            this.btnEncoder.Location = new System.Drawing.Point(442, 284);
            this.btnEncoder.Name = "btnEncoder";
            this.btnEncoder.Size = new System.Drawing.Size(75, 23);
            this.btnEncoder.TabIndex = 2;
            this.btnEncoder.Text = "Encoder";
            this.btnEncoder.UseVisualStyleBackColor = true;
            // 
            // btnChoisirDestination
            // 
            this.btnChoisirDestination.Location = new System.Drawing.Point(557, 112);
            this.btnChoisirDestination.Name = "btnChoisirDestination";
            this.btnChoisirDestination.Size = new System.Drawing.Size(75, 23);
            this.btnChoisirDestination.TabIndex = 3;
            this.btnChoisirDestination.Text = "Choisir";
            this.btnChoisirDestination.UseVisualStyleBackColor = true;
            // 
            // tbxAffichage
            // 
            this.tbxAffichage.Location = new System.Drawing.Point(192, 38);
            this.tbxAffichage.Multiline = true;
            this.tbxAffichage.Name = "tbxAffichage";
            this.tbxAffichage.ReadOnly = true;
            this.tbxAffichage.Size = new System.Drawing.Size(314, 210);
            this.tbxAffichage.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(557, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Table d\'encodage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(554, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chemin fichier destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chemin fichier source";
            // 
            // lblEntropie
            // 
            this.lblEntropie.AutoSize = true;
            this.lblEntropie.Location = new System.Drawing.Point(54, 185);
            this.lblEntropie.Name = "lblEntropie";
            this.lblEntropie.Size = new System.Drawing.Size(56, 13);
            this.lblEntropie.TabIndex = 10;
            this.lblEntropie.Text = "lblEntropie";
            // 
            // lblRedondance
            // 
            this.lblRedondance.AutoSize = true;
            this.lblRedondance.Location = new System.Drawing.Point(61, 235);
            this.lblRedondance.Name = "lblRedondance";
            this.lblRedondance.Size = new System.Drawing.Size(79, 13);
            this.lblRedondance.TabIndex = 11;
            this.lblRedondance.Text = "lblRedondance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bits avant compression :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Bits après compression :";
            // 
            // lblBitsAvant
            // 
            this.lblBitsAvant.AutoSize = true;
            this.lblBitsAvant.Location = new System.Drawing.Point(544, 214);
            this.lblBitsAvant.Name = "lblBitsAvant";
            this.lblBitsAvant.Size = new System.Drawing.Size(62, 13);
            this.lblBitsAvant.TabIndex = 14;
            this.lblBitsAvant.Text = "lblBitsAvant";
            // 
            // lblBitsApres
            // 
            this.lblBitsApres.AutoSize = true;
            this.lblBitsApres.Location = new System.Drawing.Point(554, 274);
            this.lblBitsApres.Name = "lblBitsApres";
            this.lblBitsApres.Size = new System.Drawing.Size(61, 13);
            this.lblBitsApres.TabIndex = 15;
            this.lblBitsApres.Text = "lblBitsApres";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 382);
            this.Controls.Add(this.lblBitsApres);
            this.Controls.Add(this.lblBitsAvant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRedondance);
            this.Controls.Add(this.lblEntropie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tbxAffichage);
            this.Controls.Add(this.btnChoisirDestination);
            this.Controls.Add(this.btnEncoder);
            this.Controls.Add(this.btnDecoder);
            this.Controls.Add(this.btnChoisirSource);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Shannon fano";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoisirSource;
        private System.Windows.Forms.Button btnDecoder;
        private System.Windows.Forms.Button btnEncoder;
        private System.Windows.Forms.Button btnChoisirDestination;
        private System.Windows.Forms.TextBox tbxAffichage;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEntropie;
        private System.Windows.Forms.Label lblRedondance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBitsAvant;
        private System.Windows.Forms.Label lblBitsApres;
    }
}
