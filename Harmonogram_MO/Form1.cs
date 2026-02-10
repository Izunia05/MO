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

            this.ClientSize = new Size(691, 574);

            nudCzas.MouseDown += Numeric_MouseDown;
            nudTermin.MouseDown += Numeric_MouseDown;
            nudKara.MouseDown += Numeric_MouseDown;

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


            _licznikId = 1; // Resetujemy licznik ID
            lblWynikKoszt.Text = "Koszt: -";
            lblWynikKoszt.ForeColor = Color.Black;

            currentSchedule = null;   // 🔥 czyścimy dane do Gantta
            panelGantt.Invalidate();  // 🔥 wymuszamy odświeżenie (czyli „pusty” Gantt)

            nudCzas.Value = 0;
            nudTermin.Value = 0;
            nudKara.Value = 0;


        }



        private void btnAlgorytmDP_Click(object sender, EventArgs e)
        {
            UruchomObliczenia("DP");
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
                        {
                            var wynikDP = PD_algo.Rozwiaz(_listaZadan);

                            wynik = (wynikDP.koszt, wynikDP.harmonogram);

                            lblCzas.Text = $"{wynikDP.czasTicks} ticks";
                            lblOperacje.Text = $"Liczba stanów DP: {wynikDP.dpStates}";
                            break;
                        }


                    case "BnB":
                        {
                            var wynikBnB = BnB.Rozwiaz(_listaZadan);

                            // tylko to, co wspólne dla wszystkich algorytmów
                            wynik = (wynikBnB.Item1, wynikBnB.Item2);

                            // statystyki B&B
                            lblCzas.Text = $"{wynikBnB.Item3} ticks";
                            lblOperacje.Text =
                                $"Węzły: {wynikBnB.Item4}, Odcięcia: {wynikBnB.Item5}";
                            break;
                        }


                    case "HEURYSTYKA":
                        {
                            var wynikH = Heurystyka.Rozwiaz(_listaZadan);

                            wynik = (wynikH.Item1, wynikH.Item2);

                            lblCzas.Text = $"{wynikH.Item3} ticks";
                            lblOperacje.Text = $"Kroki heurystyki: {wynikH.Item4}";
                            break;
                        }


                    default:
                        return;
                }

                

                currentSchedule = wynik.harmonogram;
                panelGantt.Invalidate();

                lblWynikKoszt.Text = $"Algorytm: {typAlgorytmu}\nKoszt: {wynik.koszt} PLN";


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
        private void Numeric_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Value == 0)
            {
                nud.BeginInvoke((Action)(() =>
                {
                    nud.Select(0, nud.Text.Length);
                }));
            }
        }

        private void nudTermin_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
