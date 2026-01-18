using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonogram_MO
{
    public class BnB
    {
        // Zmienne do przechowywania najlepszego znalezionego wyniku
        private static int _minKoszt;
        private static List<int> _najlepszaKolejnosc;

        public static (int koszt, List<int> kolejnosc) Rozwiaz(List<PD_algo.Zadanie> zadania)
        {
            // Resetujemy zmienne przed startem
            _minKoszt = int.MaxValue;
            _najlepszaKolejnosc = new List<int>();

            // Lista dostępnych zadań (kopia)
            var dostepne = new List<PD_algo.Zadanie>(zadania);

            // Start rekurencji
            Rekurencja(dostepne, 0, 0, new List<int>());

            return (_minKoszt, _najlepszaKolejnosc);
        }

        private static void Rekurencja(List<PD_algo.Zadanie> dostepne, int czasCurrent, int kosztCurrent, List<int> sciezka)
        {
            // OGRANICZENIE (BOUND):
            // Jeśli obecny koszt już jest gorszy niż najlepszy znany, zawracamy.
            if (kosztCurrent >= _minKoszt) return;

            // Jeśli lista zadań jest pusta, to znaczy, że mamy pełne rozwiązanie
            if (dostepne.Count == 0)
            {
                if (kosztCurrent < _minKoszt)
                {
                    _minKoszt = kosztCurrent;
                    _najlepszaKolejnosc = new List<int>(sciezka); // Zapisujemy wynik
                }
                return;
            }

            // PODZIAŁ (BRANCH):
            // Próbujemy każde z dostępnych zadań jako następne
            for (int i = 0; i < dostepne.Count; i++)
            {
                var zadanie = dostepne[i];

                // Symulujemy dodanie tego zadania
                int czasPoZadaniu = czasCurrent + zadanie.Czas;
                int spoznienie = Math.Max(0, czasPoZadaniu - zadanie.Termin);
                int nowyKoszt = kosztCurrent + (spoznienie * zadanie.Kara);

                // Dodajemy do ścieżki i usuwamy z dostępnych
                sciezka.Add(zadanie.Id);
                var pozostale = new List<PD_algo.Zadanie>(dostepne);
                pozostale.RemoveAt(i);

                // Schodzimy głębiej
                Rekurencja(pozostale, czasPoZadaniu, nowyKoszt, sciezka);

                // Cofamy zmianę (backtracking), żeby pętla mogła sprawdzić inne zadanie
                sciezka.RemoveAt(sciezka.Count - 1);
            }
        }
    }
}