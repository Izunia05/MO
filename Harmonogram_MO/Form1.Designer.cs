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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            lblWynikKoszt = new Label();
            btnAlgorytmDP = new Button();
            panelGantt = new Panel();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudKara).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTermin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCzas).BeginInit();
            groupboxlista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvZadania).BeginInit();
            groupBoxwynik.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnDodaj);
            groupBox1.Controls.Add(nudKara);
            groupBox1.Controls.Add(nudTermin);
            groupBox1.Controls.Add(lblOpisKary);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudCzas);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(15, 15);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(402, 220);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nowe Zadanie";
            // 
            // btnDodaj
            // 
            btnDodaj.ForeColor = SystemColors.ActiveCaptionText;
            btnDodaj.Location = new Point(91, 158);
            btnDodaj.Margin = new Padding(4);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(164, 51);
            btnDodaj.TabIndex = 6;
            btnDodaj.Text = "Dodaj Zadanie";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // nudKara
            // 
            nudKara.Location = new Point(316, 109);
            nudKara.Margin = new Padding(4);
            nudKara.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudKara.Name = "nudKara";
            nudKara.Size = new Size(76, 31);
            nudKara.TabIndex = 5;
            // 
            // nudTermin
            // 
            nudTermin.Location = new Point(317, 66);
            nudTermin.Margin = new Padding(4);
            nudTermin.Name = "nudTermin";
            nudTermin.Size = new Size(76, 31);
            nudTermin.TabIndex = 4;
            nudTermin.ValueChanged += nudTermin_ValueChanged;
            // 
            // lblOpisKary
            // 
            lblOpisKary.AutoSize = true;
            lblOpisKary.Location = new Point(19, 114);
            lblOpisKary.Margin = new Padding(4, 0, 4, 0);
            lblOpisKary.Name = "lblOpisKary";
            lblOpisKary.Size = new Size(220, 25);
            lblOpisKary.TabIndex = 3;
            lblOpisKary.Text = "Kara za spóźnienie (PLN):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(265, 25);
            label2.TabIndex = 2;
            label2.Text = "Czas na wykonanie zadania (h):";
            // 
            // nudCzas
            // 
            nudCzas.Location = new Point(318, 24);
            nudCzas.Margin = new Padding(4);
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
            label1.Size = new Size(147, 25);
            label1.TabIndex = 0;
            label1.Text = "Czas trwania (h):";
            // 
            // groupboxlista
            // 
            groupboxlista.BackColor = Color.Transparent;
            groupboxlista.Controls.Add(btnWyczysc);
            groupboxlista.Controls.Add(dgvZadania);
            groupboxlista.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupboxlista.ForeColor = SystemColors.ActiveCaptionText;
            groupboxlista.Location = new Point(442, 15);
            groupboxlista.Margin = new Padding(4);
            groupboxlista.Name = "groupboxlista";
            groupboxlista.Padding = new Padding(4);
            groupboxlista.Size = new Size(506, 463);
            groupboxlista.TabIndex = 2;
            groupboxlista.TabStop = false;
            groupboxlista.Text = "Lista Zadań";
            // 
            // btnWyczysc
            // 
            btnWyczysc.ForeColor = SystemColors.ActiveCaptionText;
            btnWyczysc.Location = new Point(177, 322);
            btnWyczysc.Margin = new Padding(4);
            btnWyczysc.Name = "btnWyczysc";
            btnWyczysc.Size = new Size(118, 64);
            btnWyczysc.TabIndex = 1;
            btnWyczysc.Text = "Wyczyść listę";
            btnWyczysc.UseVisualStyleBackColor = true;
            btnWyczysc.Click += btnWyczysc_Click;
            // 
            // dgvZadania
            // 
            dgvZadania.BackgroundColor = SystemColors.ActiveBorder;
            dgvZadania.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZadania.Location = new Point(8, 32);
            dgvZadania.Margin = new Padding(4);
            dgvZadania.Name = "dgvZadania";
            dgvZadania.RowHeadersWidth = 51;
            dgvZadania.Size = new Size(479, 252);
            dgvZadania.TabIndex = 0;
            // 
            // groupBoxwynik
            // 
            groupBoxwynik.BackColor = Color.Transparent;
            groupBoxwynik.Controls.Add(btnAlgorytmHeurystyka);
            groupBoxwynik.Controls.Add(btnAlgorytmBnB);
            groupBoxwynik.Controls.Add(lblWynikKoszt);
            groupBoxwynik.Controls.Add(btnAlgorytmDP);
            groupBoxwynik.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBoxwynik.ForeColor = SystemColors.ButtonHighlight;
            groupBoxwynik.Location = new Point(15, 256);
            groupBoxwynik.Margin = new Padding(4);
            groupBoxwynik.Name = "groupBoxwynik";
            groupBoxwynik.Padding = new Padding(4);
            groupBoxwynik.Size = new Size(420, 222);
            groupBoxwynik.TabIndex = 3;
            groupBoxwynik.TabStop = false;
            groupBoxwynik.Text = "Wynik Optymalizacji";
            // 
            // btnAlgorytmHeurystyka
            // 
            btnAlgorytmHeurystyka.ForeColor = SystemColors.ActiveCaptionText;
            btnAlgorytmHeurystyka.Location = new Point(20, 132);
            btnAlgorytmHeurystyka.Margin = new Padding(4);
            btnAlgorytmHeurystyka.Name = "btnAlgorytmHeurystyka";
            btnAlgorytmHeurystyka.Size = new Size(375, 36);
            btnAlgorytmHeurystyka.TabIndex = 4;
            btnAlgorytmHeurystyka.Text = "Oblicz Heurystyką Zachłanną";
            btnAlgorytmHeurystyka.UseVisualStyleBackColor = true;
            btnAlgorytmHeurystyka.Click += btnAlgorytmHeurystyka_Click;
            // 
            // btnAlgorytmBnB
            // 
            btnAlgorytmBnB.ForeColor = SystemColors.ActiveCaptionText;
            btnAlgorytmBnB.Location = new Point(18, 81);
            btnAlgorytmBnB.Margin = new Padding(4);
            btnAlgorytmBnB.Name = "btnAlgorytmBnB";
            btnAlgorytmBnB.Size = new Size(378, 36);
            btnAlgorytmBnB.TabIndex = 3;
            btnAlgorytmBnB.Text = "Oblicz Podziałem i Ograniczeniami";
            btnAlgorytmBnB.UseVisualStyleBackColor = true;
            btnAlgorytmBnB.Click += btnAlgorytmBnB_Click;
            // 
            // lblWynikKoszt
            // 
            lblWynikKoszt.AutoSize = true;
            lblWynikKoszt.Location = new Point(20, 172);
            lblWynikKoszt.Margin = new Padding(4, 0, 4, 0);
            lblWynikKoszt.Name = "lblWynikKoszt";
            lblWynikKoszt.Size = new Size(73, 25);
            lblWynikKoszt.TabIndex = 1;
            lblWynikKoszt.Text = "Koszt: -";
            // 
            // btnAlgorytmDP
            // 
            btnAlgorytmDP.ForeColor = SystemColors.ActiveCaptionText;
            btnAlgorytmDP.Location = new Point(15, 35);
            btnAlgorytmDP.Margin = new Padding(4);
            btnAlgorytmDP.Name = "btnAlgorytmDP";
            btnAlgorytmDP.Size = new Size(380, 36);
            btnAlgorytmDP.TabIndex = 0;
            btnAlgorytmDP.Text = "Oblicz Programowaniem Dynamicznym";
            btnAlgorytmDP.UseVisualStyleBackColor = true;
            btnAlgorytmDP.Click += btnAlgorytmDP_Click;
            // 
            // panelGantt
            // 
            panelGantt.AutoScroll = true;
            panelGantt.BackColor = SystemColors.ControlLightLight;
            panelGantt.BorderStyle = BorderStyle.FixedSingle;
            panelGantt.Dock = DockStyle.Fill;
            panelGantt.Location = new Point(3, 27);
            panelGantt.Name = "panelGantt";
            panelGantt.Size = new Size(927, 377);
            panelGantt.TabIndex = 4;
            panelGantt.Paint += panelGantt_Paint;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(panelGantt);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(14, 493);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(933, 407);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Wykres Gantta";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(969, 918);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxwynik);
            Controls.Add(groupboxlista);
            Controls.Add(groupBox1);
            Margin = new Padding(4);
            MaximizeBox = false;
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
            groupBox2.ResumeLayout(false);
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
        private Button btnAlgorytmBnB;
        private Button btnAlgorytmHeurystyka;
        private Panel panelGantt;
        private GroupBox groupBox2;
    }
}
