namespace ReadingBarCode
{
    partial class Form1
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
            this.txtLotScelles = new System.Windows.Forms.TextBox();
            this.txtTypeReception = new System.Windows.Forms.TextBox();
            this.txtProvenance = new System.Windows.Forms.TextBox();
            this.txtOrigineScelle = new System.Windows.Forms.TextBox();
            this.txtExploitationOrigine = new System.Windows.Forms.TextBox();
            this.txtDateReception = new System.Windows.Forms.TextBox();
            this.txtModificateur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvRangeScelles = new System.Windows.Forms.DataGridView();
            this.txtCodeBar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGenerer = new System.Windows.Forms.Button();
            this.NumeroDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouleurScelle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRangeScelles)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLotScelles
            // 
            this.txtLotScelles.Location = new System.Drawing.Point(148, 52);
            this.txtLotScelles.Name = "txtLotScelles";
            this.txtLotScelles.ReadOnly = true;
            this.txtLotScelles.Size = new System.Drawing.Size(217, 20);
            this.txtLotScelles.TabIndex = 1;
            // 
            // txtTypeReception
            // 
            this.txtTypeReception.Location = new System.Drawing.Point(148, 167);
            this.txtTypeReception.Name = "txtTypeReception";
            this.txtTypeReception.ReadOnly = true;
            this.txtTypeReception.Size = new System.Drawing.Size(100, 20);
            this.txtTypeReception.TabIndex = 2;
            // 
            // txtProvenance
            // 
            this.txtProvenance.Location = new System.Drawing.Point(148, 130);
            this.txtProvenance.Name = "txtProvenance";
            this.txtProvenance.Size = new System.Drawing.Size(100, 20);
            this.txtProvenance.TabIndex = 3;
            // 
            // txtOrigineScelle
            // 
            this.txtOrigineScelle.Location = new System.Drawing.Point(148, 90);
            this.txtOrigineScelle.Name = "txtOrigineScelle";
            this.txtOrigineScelle.ReadOnly = true;
            this.txtOrigineScelle.Size = new System.Drawing.Size(100, 20);
            this.txtOrigineScelle.TabIndex = 4;
            // 
            // txtExploitationOrigine
            // 
            this.txtExploitationOrigine.Location = new System.Drawing.Point(459, 130);
            this.txtExploitationOrigine.Name = "txtExploitationOrigine";
            this.txtExploitationOrigine.Size = new System.Drawing.Size(100, 20);
            this.txtExploitationOrigine.TabIndex = 5;
            // 
            // txtDateReception
            // 
            this.txtDateReception.Location = new System.Drawing.Point(459, 90);
            this.txtDateReception.Name = "txtDateReception";
            this.txtDateReception.ReadOnly = true;
            this.txtDateReception.Size = new System.Drawing.Size(100, 20);
            this.txtDateReception.TabIndex = 6;
            // 
            // txtModificateur
            // 
            this.txtModificateur.Location = new System.Drawing.Point(459, 52);
            this.txtModificateur.Name = "txtModificateur";
            this.txtModificateur.ReadOnly = true;
            this.txtModificateur.Size = new System.Drawing.Size(100, 20);
            this.txtModificateur.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Origine des Scellés";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Exploitation d\'Origine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Date de reception";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Modificateur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type de Reception";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Provenance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Numero du Lot de Scellés";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(291, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Saisie des Numéros des différentes Scellés du Lot";
            // 
            // dgvRangeScelles
            // 
            this.dgvRangeScelles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRangeScelles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroDebut,
            this.NumeroFin,
            this.CouleurScelle});
            this.dgvRangeScelles.Location = new System.Drawing.Point(15, 232);
            this.dgvRangeScelles.Name = "dgvRangeScelles";
            this.dgvRangeScelles.Size = new System.Drawing.Size(617, 150);
            this.dgvRangeScelles.TabIndex = 16;
            // 
            // txtCodeBar
            // 
            this.txtCodeBar.Location = new System.Drawing.Point(118, 12);
            this.txtCodeBar.Name = "txtCodeBar";
            this.txtCodeBar.Size = new System.Drawing.Size(100, 20);
            this.txtCodeBar.TabIndex = 17;
            this.txtCodeBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeBar_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Code Barre";
            // 
            // btnGenerer
            // 
            this.btnGenerer.Location = new System.Drawing.Point(553, 191);
            this.btnGenerer.Name = "btnGenerer";
            this.btnGenerer.Size = new System.Drawing.Size(75, 23);
            this.btnGenerer.TabIndex = 19;
            this.btnGenerer.Text = "Generer";
            this.btnGenerer.UseVisualStyleBackColor = true;
            this.btnGenerer.Click += new System.EventHandler(this.btnGenerer_Click);
            // 
            // NumeroDebut
            // 
            this.NumeroDebut.HeaderText = "Numéro du début";
            this.NumeroDebut.Name = "NumeroDebut";
            this.NumeroDebut.ReadOnly = true;
            this.NumeroDebut.Width = 200;
            // 
            // NumeroFin
            // 
            this.NumeroFin.HeaderText = "Numéro de Fin";
            this.NumeroFin.Name = "NumeroFin";
            this.NumeroFin.ReadOnly = true;
            this.NumeroFin.Width = 200;
            // 
            // CouleurScelle
            // 
            this.CouleurScelle.HeaderText = "Couleur des Scellés";
            this.CouleurScelle.Items.AddRange(new object[] {
            "Bleu",
            "Rouge",
            "Vert",
            "Violet",
            "Jaune",
            "Noir"});
            this.CouleurScelle.Name = "CouleurScelle";
            this.CouleurScelle.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 397);
            this.Controls.Add(this.btnGenerer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCodeBar);
            this.Controls.Add(this.dgvRangeScelles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModificateur);
            this.Controls.Add(this.txtDateReception);
            this.Controls.Add(this.txtExploitationOrigine);
            this.Controls.Add(this.txtOrigineScelle);
            this.Controls.Add(this.txtProvenance);
            this.Controls.Add(this.txtTypeReception);
            this.Controls.Add(this.txtLotScelles);
            this.Name = "Form1";
            this.Text = "Reception Scelles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRangeScelles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotScelles;
        private System.Windows.Forms.TextBox txtTypeReception;
        private System.Windows.Forms.TextBox txtProvenance;
        private System.Windows.Forms.TextBox txtOrigineScelle;
        private System.Windows.Forms.TextBox txtExploitationOrigine;
        private System.Windows.Forms.TextBox txtDateReception;
        private System.Windows.Forms.TextBox txtModificateur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvRangeScelles;
        private System.Windows.Forms.TextBox txtCodeBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGenerer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroFin;
        private System.Windows.Forms.DataGridViewComboBoxColumn CouleurScelle;
    }
}

