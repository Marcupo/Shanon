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
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.tbxDestination = new System.Windows.Forms.TextBox();
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
            this.btnChoisirSource.Enabled = false;
            this.btnChoisirSource.Location = new System.Drawing.Point(9, 96);
            this.btnChoisirSource.Name = "btnChoisirSource";
            this.btnChoisirSource.Size = new System.Drawing.Size(259, 23);
            this.btnChoisirSource.TabIndex = 1;
            this.btnChoisirSource.Text = "Choisir";
            this.btnChoisirSource.UseVisualStyleBackColor = true;
            // 
            // btnDecoder
            // 
            this.btnDecoder.Location = new System.Drawing.Point(12, 440);
            this.btnDecoder.Name = "btnDecoder";
            this.btnDecoder.Size = new System.Drawing.Size(126, 48);
            this.btnDecoder.TabIndex = 5;
            this.btnDecoder.Text = "Decoder";
            this.btnDecoder.UseVisualStyleBackColor = true;
            this.btnDecoder.Click += new System.EventHandler(this.BtnDecoder_Click);
            // 
            // btnEncoder
            // 
            this.btnEncoder.Location = new System.Drawing.Point(142, 440);
            this.btnEncoder.Name = "btnEncoder";
            this.btnEncoder.Size = new System.Drawing.Size(126, 48);
            this.btnEncoder.TabIndex = 2;
            this.btnEncoder.Text = "Encoder";
            this.btnEncoder.UseVisualStyleBackColor = true;
            this.btnEncoder.Click += new System.EventHandler(this.BtnEncoder_Click);
            // 
            // btnChoisirDestination
            // 
            this.btnChoisirDestination.Enabled = false;
            this.btnChoisirDestination.Location = new System.Drawing.Point(9, 176);
            this.btnChoisirDestination.Name = "btnChoisirDestination";
            this.btnChoisirDestination.Size = new System.Drawing.Size(259, 23);
            this.btnChoisirDestination.TabIndex = 4;
            this.btnChoisirDestination.Text = "Choisir";
            this.btnChoisirDestination.UseVisualStyleBackColor = true;
            // 
            // tbxAffichage
            // 
            this.tbxAffichage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAffichage.Location = new System.Drawing.Point(274, 49);
            this.tbxAffichage.Multiline = true;
            this.tbxAffichage.Name = "tbxAffichage";
            this.tbxAffichage.ReadOnly = true;
            this.tbxAffichage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxAffichage.Size = new System.Drawing.Size(687, 463);
            this.tbxAffichage.TabIndex = 4;
            // 
            // tbxSource
            // 
            this.tbxSource.Location = new System.Drawing.Point(9, 70);
            this.tbxSource.Name = "tbxSource";
            this.tbxSource.Size = new System.Drawing.Size(259, 20);
            this.tbxSource.TabIndex = 0;
            this.tbxSource.Text = "Source.txt";
            // 
            // tbxDestination
            // 
            this.tbxDestination.Location = new System.Drawing.Point(9, 150);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.Size = new System.Drawing.Size(259, 20);
            this.tbxDestination.TabIndex = 3;
            this.tbxDestination.Text = "Destination.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table d\'encodage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chemin fichier destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Chemin fichier source";
            // 
            // lblEntropie
            // 
            this.lblEntropie.AutoSize = true;
            this.lblEntropie.Location = new System.Drawing.Point(26, 359);
            this.lblEntropie.Name = "lblEntropie";
            this.lblEntropie.Size = new System.Drawing.Size(55, 13);
            this.lblEntropie.TabIndex = 0;
            this.lblEntropie.Text = "Entropie : ";
            // 
            // lblRedondance
            // 
            this.lblRedondance.AutoSize = true;
            this.lblRedondance.Location = new System.Drawing.Point(25, 384);
            this.lblRedondance.Name = "lblRedondance";
            this.lblRedondance.Size = new System.Drawing.Size(78, 13);
            this.lblRedondance.TabIndex = 0;
            this.lblRedondance.Text = "Redondance : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bits avant compression :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bits après compression :";
            // 
            // lblBitsAvant
            // 
            this.lblBitsAvant.AutoSize = true;
            this.lblBitsAvant.Location = new System.Drawing.Point(27, 250);
            this.lblBitsAvant.Name = "lblBitsAvant";
            this.lblBitsAvant.Size = new System.Drawing.Size(32, 13);
            this.lblBitsAvant.TabIndex = 0;
            this.lblBitsAvant.Text = "0 bits";
            // 
            // lblBitsApres
            // 
            this.lblBitsApres.AutoSize = true;
            this.lblBitsApres.Location = new System.Drawing.Point(26, 314);
            this.lblBitsApres.Name = "lblBitsApres";
            this.lblBitsApres.Size = new System.Drawing.Size(32, 13);
            this.lblBitsApres.TabIndex = 0;
            this.lblBitsApres.Text = "0 bits";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnEncoder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 524);
            this.Controls.Add(this.lblBitsApres);
            this.Controls.Add(this.lblBitsAvant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRedondance);
            this.Controls.Add(this.lblEntropie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.tbxAffichage);
            this.Controls.Add(this.btnChoisirDestination);
            this.Controls.Add(this.btnEncoder);
            this.Controls.Add(this.btnDecoder);
            this.Controls.Add(this.btnChoisirSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.TextBox tbxDestination;
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

