using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Ważne do obsługi list
using System.Windows.Forms;
using Harmonogram_MO;

namespace Harmonogram_MO
{
    public partial class Form1 : Form
    {
        private List<PD_algo.Zadanie> _listaZadan = new List<PD_algo.Zadanie>();
        private int _licznikId = 1;

        public Form1()
        {
            InitializeComponent();
            KonfigurujTabele();
        }
        private void KonfigurujTabele()
        {
            // Ustawiamy kolumny tabeli kodem, żeby było ładnie
            dgvZadania.ColumnCount = 4;
            dgvZadania.Columns[0].Name = "ID";
            dgvZadania.Columns[1].Name = "Czas (h)";
            dgvZadania.Columns[2].Name = "Termin (h)";
            dgvZadania.Columns[3].Name = "Kara (PLN)";

            // Tabela ma wypełniać całą szerokość
            dgvZadania.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Użytkownik nie może edytować tabeli ręcznie (tylko przez panel dodawania)
            dgvZadania.ReadOnly = true;
            dgvZadania.AllowUserToAddRows = false;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int czas = (int)nudCzas.Value;
            int termin = (int)nudTermin.Value;
            int kara = (int)nudKara.Value;

            // Tworzymy obiekt zadania (korzystamy z Twojej klasy w PD_algo.cs)
            var noweZadanie = new PD_algo.Zadanie
            {
                Id = _licznikId++, // Przypisz ID i zwiększ licznik
                Czas = czas,
                Termin = termin,
                Kara = kara
            };
            _listaZadan.Add(noweZadanie);
            dgvZadania.Rows.Add(noweZadanie.Id, noweZadanie.Czas, noweZadanie.Termin, noweZadanie.Kara);
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            _listaZadan.Clear();
            dgvZadania.Rows.Clear();
            flpWynik.Controls.Clear();

            _licznikId = 1; // Resetujemy licznik ID
            lblWynikKoszt.Text = "Koszt: -";
            lblWynikKoszt.ForeColor = Color.Black;
        }

        private void btnObliczprawidlowy_Click(object sender, EventArgs e)
        {
            if (_listaZadan.Count == 0)
            {
                MessageBox.Show("Lista zadań jest pusta! Dodaj coś najpierw.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                var wynik = PD_algo.Rozwiaz(_listaZadan);

                // Wyświetlanie kosztu
                lblWynikKoszt.Text = $"Minimalny Koszt Kar: {wynik.koszt} PLN";
                // Zmieniamy kolor: Zielony = Super (0 kary), Czerwony = Płacimy
                if (wynik.koszt == 0)
                    lblWynikKoszt.ForeColor = Color.Green;
                else
                    lblWynikKoszt.ForeColor = Color.Red;

                // Wizualizacja klocków w FlowLayoutPanel
                WizualizujWynik(wynik.kolejnosc);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas obliczeń:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WizualizujWynik(List<int> kolejnoscId)
        {
            // Najpierw czyścimy stare wyniki
            flpWynik.Controls.Clear();

            foreach (int id in kolejnoscId)
            {
                // Znajdźmy szczegóły tego zadania w naszej liście
                var zadanie = _listaZadan.FirstOrDefault(z => z.Id == id);
                if (zadanie == null) continue;

                // Tworzymy "klocek" (Button, bo wygląda ładnie)
                Button klocek = new Button();
                klocek.Text = $"ID: {id}\n({zadanie.Czas}h)";
                klocek.Size = new Size(80, 50);
                klocek.BackColor = Color.LightSkyBlue;
                klocek.FlatStyle = FlatStyle.Flat;
                klocek.FlatAppearance.BorderSize = 0;
                klocek.Enabled = false; // Żeby nie dało się go klikać, ma tylko wyglądać
                klocek.ForeColor = Color.Black;
                klocek.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // Dodajemy klocek do panelu
                flpWynik.Controls.Add(klocek);

                // Jeśli to nie jest ostatni element, dodajemy strzałkę
                if (id != kolejnoscId.Last())
                {
                    Label strzalka = new Label();
                    strzalka.Text = "➜";
                    strzalka.AutoSize = true;
                    strzalka.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                    strzalka.ForeColor = Color.Gray;
                    // Centrowanie strzałki w pionie (margines górny)
                    strzalka.Margin = new Padding(0, 15, 0, 0);

                    flpWynik.Controls.Add(strzalka);
                }
            }
        }
    }
}
