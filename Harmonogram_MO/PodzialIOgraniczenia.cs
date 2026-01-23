using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonogram_MO
{
    public class BnB
    {
        // Najlepszy znaleziony wynik
        private static int _minKoszt;
        private static List<int> _najlepszaKolejnosc;

        public static (int koszt, List<ScheduledTask> harmonogram)
            Rozwiaz(List<PD_algo.Zadanie> zadania)
        {
            _minKoszt = int.MaxValue;
            _najlepszaKolejnosc = new List<int>();

            var dostepne = new List<PD_algo.Zadanie>(zadania);

            // START rekurencji — UWAGA: List<int>
            Rekurencja(dostepne, 0, 0, new List<int>());

            // 🔥 KONWERSJA NA HARMONOGRAM (DO GANTTA)
            List<ScheduledTask> harmonogram = new List<ScheduledTask>();
            int obecnyCzas = 0;

            foreach (int id in _najlepszaKolejnosc)
            {
                var z = zadania.First(x => x.Id == id);

                harmonogram.Add(new ScheduledTask
                {
                    Id = z.Id,
                    Name = $"Zadanie {z.Id}",
                    StartTime = obecnyCzas,
                    Duration = z.Czas,
                    Priority = z.Kara
                });

                obecnyCzas += z.Czas;
            }

            return (_minKoszt, harmonogram);
        }

        private static void Rekurencja(
            List<PD_algo.Zadanie> dostepne,
            int czasCurrent,
            int kosztCurrent,
            List<int> sciezka)
        {
            // BOUND
            if (kosztCurrent >= _minKoszt)
                return;

            // Pełne rozwiązanie
            if (dostepne.Count == 0)
            {
                if (kosztCurrent < _minKoszt)
                {
                    _minKoszt = kosztCurrent;
                    _najlepszaKolejnosc = new List<int>(sciezka);
                }
                return;
            }

            // BRANCH
            for (int i = 0; i < dostepne.Count; i++)
            {
                var zadanie = dostepne[i];

                int czasPo = czasCurrent + zadanie.Czas;
                int spoznienie = Math.Max(0, czasPo - zadanie.Termin);
                int nowyKoszt = kosztCurrent + spoznienie * zadanie.Kara;

                sciezka.Add(zadanie.Id);

                var pozostale = new List<PD_algo.Zadanie>(dostepne);
                pozostale.RemoveAt(i);

                Rekurencja(pozostale, czasPo, nowyKoszt, sciezka);

                // backtracking
                sciezka.RemoveAt(sciezka.Count - 1);
            }
        }
    }
}
