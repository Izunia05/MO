using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Harmonogram_MO
{
    public class BnB
    {
        // ===== NAJLEPSZY WYNIK =====
        private static int _minKoszt;
        private static List<int> _najlepszaKolejnosc;

        // ===== LICZNIKI EKSPERYMENTALNE =====
        public static long visitedNodes = 0;
        public static long prunedNodes = 0;

        // ===== ALGORYTM B&B =====
        public static (int koszt,
                       List<ScheduledTask> harmonogram,
                       long czasMs,
                       long visitedNodes,
                       long prunedNodes)
            Rozwiaz(List<PD_algo.Zadanie> zadania)
        {
            _minKoszt = int.MaxValue;
            _najlepszaKolejnosc = new List<int>();

            visitedNodes = 0;
            prunedNodes = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var dostepne = new List<PD_algo.Zadanie>(zadania);

            Rekurencja(dostepne, 0, 0, new List<int>());

            // ===== KONWERSJA NA HARMONOGRAM =====
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

            stopwatch.Stop();
            long timeTicks = stopwatch.ElapsedTicks;


            return (_minKoszt, harmonogram, timeTicks, visitedNodes, prunedNodes);
        }

        private static void Rekurencja(
            List<PD_algo.Zadanie> dostepne,
            int czasCurrent,
            int kosztCurrent,
            List<int> sciezka)
        {
            visitedNodes++; // ===== ODWIEDZONY WĘZEŁ =====

            // ===== BOUND (ODCIĘCIE) =====
            if (kosztCurrent >= _minKoszt)
            {
                prunedNodes++;
                return;
            }

            // ===== PEŁNE ROZWIĄZANIE =====
            if (dostepne.Count == 0)
            {
                if (kosztCurrent < _minKoszt)
                {
                    _minKoszt = kosztCurrent;
                    _najlepszaKolejnosc = new List<int>(sciezka);
                }
                return;
            }

            // ===== BRANCH =====
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

                // ===== BACKTRACKING =====
                sciezka.RemoveAt(sciezka.Count - 1);
            }
        }
    }
}
