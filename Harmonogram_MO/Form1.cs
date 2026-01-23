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

        private List<ScheduledTask> currentSchedule;
        private Gantt gantt = new Gantt();

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

            currentSchedule = null;   // 🔥 czyścimy dane do Gantta
            panelGantt.Invalidate();  // 🔥 wymuszamy odświeżenie (czyli „pusty” Gantt)

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
        private void btnAlgorytmDP_Click(object sender, EventArgs e)
        {
            UruchomObliczenia("DP");
            var wynik = PD_algo.Rozwiaz(_listaZadan);

        }

        private void btnAlgorytmBnB_Click(object sender, EventArgs e)
        {
            UruchomObliczenia("BnB");

        }

        private void btnAlgorytmHeurystyka_Click(object sender, EventArgs e)
        {
            UruchomObliczenia("HEURYSTYKA");

            var wynik = Heurystyka.Rozwiaz(_listaZadan);


        }


        private void UruchomObliczenia(string typAlgorytmu)
        {
            // 1. Sprawdzenie czy są zadania
            if (_listaZadan.Count == 0)
            {
                MessageBox.Show("Dodaj najpierw zadania!", "Pusto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Informacja dla użytkownika, że liczymy
            lblWynikKoszt.Text = "Obliczam...";
            lblWynikKoszt.ForeColor = Color.Blue;
            Application.DoEvents(); // Odświeża okno, żeby napis się pojawił

            try
            {
                (int koszt, List<ScheduledTask> harmonogram) wynik;

                switch (typAlgorytmu)
                {
                    case "DP":
                        wynik = PD_algo.Rozwiaz(_listaZadan);
                        break;

                    case "BnB":
                        wynik = BnB.Rozwiaz(_listaZadan);
                        break;

                    case "HEURYSTYKA":
                        wynik = Heurystyka.Rozwiaz(_listaZadan);
                        break;

                    default:
                        MessageBox.Show("Ten algorytm jeszcze nie obsługuje Gantta");
                        return;
                }

                // 🔥 TU „odpalamy” Gantta
                currentSchedule = wynik.harmonogram;
                panelGantt.Invalidate();


                // 4. Wyświetlenie wyniku (To samo co wcześniej, ale teraz uniwersalne)
                lblWynikKoszt.Text = $"Algorytm: {typAlgorytmu}\nKoszt: {wynik.koszt} PLN";

                if (wynik.koszt == 0) lblWynikKoszt.ForeColor = Color.Green;
                else lblWynikKoszt.ForeColor = Color.Red;

                currentSchedule = wynik.harmonogram;
                panelGantt.Invalidate();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }

        }

        private void panelGantt_Paint(object sender, PaintEventArgs e)
        {
            if (currentSchedule != null && currentSchedule.Count > 0)
            {
                gantt.DrawGantt(e.Graphics, currentSchedule);
            }
        }

    }
}
