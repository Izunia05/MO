namespace Harmonogram_MO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnDodaj = new Button();
            nudKara = new NumericUpDown();
            nudTermin = new NumericUpDown();
            lblOpisKary = new Label();
            label2 = new Label();
            nudCzas = new NumericUpDown();
            label1 = new Label();
            groupboxlista = new GroupBox();
            btnWyczysc = new Button();
            dgvZadania = new DataGridView();
            groupBoxwynik = new GroupBox();
            btnAlgorytmHeurystyka = new Button();
            btnAlgorytmBnB = new Button();
            flpWynik = new FlowLayoutPanel();
            lblWynikKoszt = new Label();
            btnAlgorytmDP = new Button();
            panelGantt = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudKara).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTermin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCzas).BeginInit();
            groupboxlista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvZadania).BeginInit();
            groupBoxwynik.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDodaj);
            groupBox1.Controls.Add(nudKara);
            groupBox1.Controls.Add(nudTermin);
            groupBox1.Controls.Add(lblOpisKary);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudCzas);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 15);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(402, 220);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nowe Zadanie";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(91, 158);
            btnDodaj.Margin = new Padding(4, 4, 4, 4);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(164, 51);
            btnDodaj.TabIndex = 6;
            btnDodaj.Text = "Dodaj Zadanie";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // nudKara
            // 
            nudKara.Location = new Point(256, 111);
            nudKara.Margin = new Padding(4, 4, 4, 4);
            nudKara.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudKara.Name = "nudKara";
            nudKara.Size = new Size(76, 31);
            nudKara.TabIndex = 5;
            // 
            // nudTermin
            // 
            nudTermin.Location = new Point(256, 66);
            nudTermin.Margin = new Padding(4, 4, 4, 4);
            nudTermin.Name = "nudTermin";
            nudTermin.Size = new Size(76, 31);
            nudTermin.TabIndex = 4;
            // 
            // lblOpisKary
            // 
            lblOpisKary.AutoSize = true;
            lblOpisKary.Location = new Point(19, 114);
            lblOpisKary.Margin = new Padding(4, 0, 4, 0);
            lblOpisKary.Name = "lblOpisKary";
            lblOpisKary.Size = new Size(161, 25);
            lblOpisKary.TabIndex = 3;
            lblOpisKary.Text = "Kara za spóźnienie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 2;
            label2.Text = "Termin:";
            // 
            // nudCzas
            // 
            nudCzas.Location = new Point(256, 25);
            nudCzas.Margin = new Padding(4, 4, 4, 4);
            nudCzas.Name = "nudCzas";
            nudCzas.Size = new Size(76, 31);
            nudCzas.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 25);
            label1.TabIndex = 0;
            label1.Text = "Czas trwania (h):";
            // 
            // groupboxlista
            // 
            groupboxlista.Controls.Add(btnWyczysc);
            groupboxlista.Controls.Add(dgvZadania);
            groupboxlista.Location = new Point(442, 40);
            groupboxlista.Margin = new Padding(4, 4, 4, 4);
            groupboxlista.Name = "groupboxlista";
            groupboxlista.Padding = new Padding(4, 4, 4, 4);
            groupboxlista.Size = new Size(506, 438);
            groupboxlista.TabIndex = 2;
            groupboxlista.TabStop = false;
            groupboxlista.Text = "Lista Zadań";
            // 
            // btnWyczysc
            // 
            btnWyczysc.Location = new Point(181, 300);
            btnWyczysc.Margin = new Padding(4, 4, 4, 4);
            btnWyczysc.Name = "btnWyczysc";
            btnWyczysc.Size = new Size(118, 64);
            btnWyczysc.TabIndex = 1;
            btnWyczysc.Text = "Wyczyść listę";
            btnWyczysc.UseVisualStyleBackColor = true;
            btnWyczysc.Click += btnWyczysc_Click;
            // 
            // dgvZadania
            // 
            dgvZadania.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZadania.Location = new Point(8, 32);
            dgvZadania.Margin = new Padding(4, 4, 4, 4);
            dgvZadania.Name = "dgvZadania";
            dgvZadania.RowHeadersWidth = 51;
            dgvZadania.Size = new Size(479, 252);
            dgvZadania.TabIndex = 0;
            // 
            // groupBoxwynik
            // 
            groupBoxwynik.Controls.Add(btnAlgorytmHeurystyka);
            groupBoxwynik.Controls.Add(btnAlgorytmBnB);
            groupBoxwynik.Controls.Add(flpWynik);
            groupBoxwynik.Controls.Add(lblWynikKoszt);
            groupBoxwynik.Controls.Add(btnAlgorytmDP);
            groupBoxwynik.Location = new Point(15, 256);
            groupBoxwynik.Margin = new Padding(4, 4, 4, 4);
            groupBoxwynik.Name = "groupBoxwynik";
            groupBoxwynik.Padding = new Padding(4, 4, 4, 4);
            groupBoxwynik.Size = new Size(420, 610);
            groupBoxwynik.TabIndex = 3;
            groupBoxwynik.TabStop = false;
            groupBoxwynik.Text = "Wynik Optymalizacji";
            // 
            // btnAlgorytmHeurystyka
            // 
            btnAlgorytmHeurystyka.Location = new Point(20, 132);
            btnAlgorytmHeurystyka.Margin = new Padding(4, 4, 4, 4);
            btnAlgorytmHeurystyka.Name = "btnAlgorytmHeurystyka";
            btnAlgorytmHeurystyka.Size = new Size(375, 36);
            btnAlgorytmHeurystyka.TabIndex = 4;
            btnAlgorytmHeurystyka.Text = "Oblicz Heurystyką Zachłanną";
            btnAlgorytmHeurystyka.UseVisualStyleBackColor = true;
            btnAlgorytmHeurystyka.Click += btnAlgorytmHeurystyka_Click;
            // 
            // btnAlgorytmBnB
            // 
            btnAlgorytmBnB.Location = new Point(18, 81);
            btnAlgorytmBnB.Margin = new Padding(4, 4, 4, 4);
            btnAlgorytmBnB.Name = "btnAlgorytmBnB";
            btnAlgorytmBnB.Size = new Size(378, 36);
            btnAlgorytmBnB.TabIndex = 3;
            btnAlgorytmBnB.Text = "Oblicz Podziałem i Ograniczeniami";
            btnAlgorytmBnB.UseVisualStyleBackColor = true;
            btnAlgorytmBnB.Click += btnAlgorytmBnB_Click;
            // 
            // flpWynik
            // 
            flpWynik.AutoScroll = true;
            flpWynik.BackColor = SystemColors.ButtonHighlight;
            flpWynik.Location = new Point(19, 280);
            flpWynik.Margin = new Padding(4, 4, 4, 4);
            flpWynik.Name = "flpWynik";
            flpWynik.Size = new Size(361, 310);
            flpWynik.TabIndex = 2;
            // 
            // lblWynikKoszt
            // 
            lblWynikKoszt.AutoSize = true;
            lblWynikKoszt.Location = new Point(20, 172);
            lblWynikKoszt.Margin = new Padding(4, 0, 4, 0);
            lblWynikKoszt.Name = "lblWynikKoszt";
            lblWynikKoszt.Size = new Size(71, 25);
            lblWynikKoszt.TabIndex = 1;
            lblWynikKoszt.Text = "Koszt: -";
            // 
            // btnAlgorytmDP
            // 
            btnAlgorytmDP.Location = new Point(15, 35);
            btnAlgorytmDP.Margin = new Padding(4, 4, 4, 4);
            btnAlgorytmDP.Name = "btnAlgorytmDP";
            btnAlgorytmDP.Size = new Size(380, 36);
            btnAlgorytmDP.TabIndex = 0;
            btnAlgorytmDP.Text = "Oblicz Programowaniem Dynamicznym";
            btnAlgorytmDP.UseVisualStyleBackColor = true;
            btnAlgorytmDP.Click += btnAlgorytmDP_Click;
            // 
            // panelGantt
            // 
            panelGantt.BackColor = SystemColors.ControlLightLight;
            panelGantt.BorderStyle = BorderStyle.FixedSingle;
            panelGantt.Location = new Point(461, 504);
            panelGantt.Name = "panelGantt";
            panelGantt.Size = new Size(509, 370);
            panelGantt.TabIndex = 4;
            panelGantt.Paint += panelGantt_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 912);
            Controls.Add(panelGantt);
            Controls.Add(groupBoxwynik);
            Controls.Add(groupboxlista);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudKara).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTermin).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCzas).EndInit();
            groupboxlista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvZadania).EndInit();
            groupBoxwynik.ResumeLayout(false);
            groupBoxwynik.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private NumericUpDown nudCzas;
        private Label label1;
        private Button btnDodaj;
        private NumericUpDown nudKara;
        private NumericUpDown nudTermin;
        private Label lblOpisKary;
        private Label label2;
        private GroupBox groupboxlista;
        private Button btnWyczysc;
        private DataGridView dgvZadania;
        private GroupBox groupBoxwynik;
        private Label lblWynikKoszt;
        private Button btnAlgorytmDP;
        private FlowLayoutPanel flpWynik;
        private Button btnAlgorytmBnB;
        private Button btnAlgorytmHeurystyka;
        private Panel panelGantt;
    }
}
