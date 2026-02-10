using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Harmonogram_MO
{
    public class Heurystyka
    {
        // ===== LICZNIK OPERACJI HEURYSTYKI =====
        public static long heuristicSteps = 0;

        public static (int koszt,
                       List<ScheduledTask> harmonogram,
                       long czasTicks,
                       long heuristicSteps)
            Rozwiaz(List<PD_algo.Zadanie> zadania)
        {
            // === START POMIARU CZASU ===
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            heuristicSteps = 0;

            // 1. Kopiujemy listę
            var posortowane = new List<PD_algo.Zadanie>(zadania);

            // 2. SORTOWANIE (EDD + kara)
            posortowane.Sort((a, b) =>
            {
                heuristicSteps++; // jedno porównanie

                int porownanieTerminow = a.Termin.CompareTo(b.Termin);
                if (porownanieTerminow != 0) return porownanieTerminow;
                return b.Kara.CompareTo(a.Kara);
            });

            int obecnyCzas = 0;
            int calkowitaKara = 0;

            List<ScheduledTask> harmonogram = new List<ScheduledTask>();

            // 3. Budowa harmonogramu
            foreach (var z in posortowane)
            {
                heuristicSteps++; // jedna decyzja planowania

                int start = obecnyCzas;
                obecnyCzas += z.Czas;

                int spoznienie = Math.Max(0, obecnyCzas - z.Termin);
                calkowitaKara += spoznienie * z.Kara;

                harmonogram.Add(new ScheduledTask
                {
                    Id = z.Id,
                    Name = $"Zadanie {z.Id}",
                    StartTime = start,
                    Duration = z.Czas,
                    Priority = z.Kara
                });
            }

            // === STOP POMIARU CZASU ===
            stopwatch.Stop();
            long timeTicks = stopwatch.ElapsedTicks;

            return (calkowitaKara, harmonogram, timeTicks, heuristicSteps);
        }
    }
}
