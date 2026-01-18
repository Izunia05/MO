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
            flpWynik = new FlowLayoutPanel();
            lblWynikKoszt = new Label();
            btnObliczprawidlowy = new Button();
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
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(322, 176);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nowe Zadanie";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(73, 126);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(131, 41);
            btnDodaj.TabIndex = 6;
            btnDodaj.Text = "Dodaj Zadanie";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // nudKara
            // 
            nudKara.Location = new Point(205, 89);
            nudKara.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudKara.Name = "nudKara";
            nudKara.Size = new Size(61, 27);
            nudKara.TabIndex = 5;
            // 
            // nudTermin
            // 
            nudTermin.Location = new Point(205, 53);
            nudTermin.Name = "nudTermin";
            nudTermin.Size = new Size(61, 27);
            nudTermin.TabIndex = 4;
            // 
            // lblOpisKary
            // 
            lblOpisKary.AutoSize = true;
            lblOpisKary.Location = new Point(15, 91);
            lblOpisKary.Name = "lblOpisKary";
            lblOpisKary.Size = new Size(136, 20);
            lblOpisKary.TabIndex = 3;
            lblOpisKary.Text = "Kara za spóźnienie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 60);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 2;
            label2.Text = "Termin:";
            // 
            // nudCzas
            // 
            nudCzas.Location = new Point(205, 20);
            nudCzas.Name = "nudCzas";
            nudCzas.Size = new Size(61, 27);
            nudCzas.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 27);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Czas trwania (h):";
            // 
            // groupboxlista
            // 
            groupboxlista.Controls.Add(btnWyczysc);
            groupboxlista.Controls.Add(dgvZadania);
            groupboxlista.Location = new Point(354, 32);
            groupboxlista.Name = "groupboxlista";
            groupboxlista.Size = new Size(405, 350);
            groupboxlista.TabIndex = 2;
            groupboxlista.TabStop = false;
            groupboxlista.Text = "Lista Zadań";
            // 
            // btnWyczysc
            // 
            btnWyczysc.Location = new Point(145, 240);
            btnWyczysc.Name = "btnWyczysc";
            btnWyczysc.Size = new Size(94, 51);
            btnWyczysc.TabIndex = 1;
            btnWyczysc.Text = "Wyczyść listę";
            btnWyczysc.UseVisualStyleBackColor = true;
            btnWyczysc.Click += btnWyczysc_Click;
            // 
            // dgvZadania
            // 
            dgvZadania.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZadania.Location = new Point(6, 26);
            dgvZadania.Name = "dgvZadania";
            dgvZadania.RowHeadersWidth = 51;
            dgvZadania.Size = new Size(383, 202);
            dgvZadania.TabIndex = 0;
            // 
            // groupBoxwynik
            // 
            groupBoxwynik.Controls.Add(flpWynik);
            groupBoxwynik.Controls.Add(lblWynikKoszt);
            groupBoxwynik.Controls.Add(btnObliczprawidlowy);
            groupBoxwynik.Location = new Point(12, 205);
            groupBoxwynik.Name = "groupBoxwynik";
            groupBoxwynik.Size = new Size(322, 381);
            groupBoxwynik.TabIndex = 3;
            groupBoxwynik.TabStop = false;
            groupBoxwynik.Text = "Wynik Optymalizacji";
            // 
            // flpWynik
            // 
            flpWynik.AutoScroll = true;
            flpWynik.BackColor = SystemColors.ButtonHighlight;
            flpWynik.Location = new Point(16, 108);
            flpWynik.Name = "flpWynik";
            flpWynik.Size = new Size(289, 248);
            flpWynik.TabIndex = 2;
            // 
            // lblWynikKoszt
            // 
            lblWynikKoszt.AutoSize = true;
            lblWynikKoszt.Location = new Point(12, 67);
            lblWynikKoszt.Name = "lblWynikKoszt";
            lblWynikKoszt.Size = new Size(58, 20);
            lblWynikKoszt.TabIndex = 1;
            lblWynikKoszt.Text = "Koszt: -";
            // 
            // btnObliczprawidlowy
            // 
            btnObliczprawidlowy.Location = new Point(12, 28);
            btnObliczprawidlowy.Name = "btnObliczprawidlowy";
            btnObliczprawidlowy.Size = new Size(94, 29);
            btnObliczprawidlowy.TabIndex = 0;
            btnObliczprawidlowy.Text = "Oblicz Harmonogram";
            btnObliczprawidlowy.UseVisualStyleBackColor = true;
            btnObliczprawidlowy.Click += btnObliczprawidlowy_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 612);
            Controls.Add(groupBoxwynik);
            Controls.Add(groupboxlista);
            Controls.Add(groupBox1);
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
        private Button btnObliczprawidlowy;
        private FlowLayoutPanel flpWynik;
    }
}
