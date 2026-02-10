using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Harmonogram_MO
{
    public class PD_algo
    {
        // ===== LICZNIK STANÓW DP =====
        public static long dpStates = 0;

        public class Zadanie
        {
            public int Id { get; set; }
            public int Czas { get; set; }     // Processing time
            public int Termin { get; set; }   // Deadline
            public int Kara { get; set; }     // Waga kary
        }

        // ===== ALGORYTM DP =====
        public static (int koszt,
                       List<ScheduledTask> harmonogram,
                       long czasTicks,
                       long dpStates)
            Rozwiaz(List<Zadanie> zadania)
        {
            // === START POMIARU CZASU ===
            Stopwatch stopwatch = Stopwatch.StartNew();

            dpStates = 0; // reset licznika

            int n = zadania.Count;
            int maxMask = 1 << n;

            int[] dp = new int[maxMask];
            int[] czas = new int[maxMask];
            int[] parent = new int[maxMask];

            // Inicjalizacja
            for (int i = 0; i < maxMask; i++)
            {
                dp[i] = int.MaxValue;
                czas[i] = 0;
                parent[i] = -1;
            }

            dp[0] = 0;

            // Pre-kalkulacja czasów
            for (int mask = 0; mask < maxMask; mask++)
            {
                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) != 0)
                        czas[mask] += zadania[i].Czas;
                }
            }

            // === GŁÓWNA PĘTLA DP ===
            for (int mask = 1; mask < maxMask; mask++)
            {
                dpStates++; // LICZYMY STAN DP

                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        int prevMask = mask ^ (1 << i);

                        if (dp[prevMask] == int.MaxValue)
                            continue;

                        int czasZakonczenia = czas[mask];
                        int opoznienie = Math.Max(0, czasZakonczenia - zadania[i].Termin);

                        long nowyKoszt =
                            (long)dp[prevMask] +
                            (long)opoznienie * zadania[i].Kara;

                        if (nowyKoszt < dp[mask])
                        {
                            dp[mask] = (int)nowyKoszt;
                            parent[mask] = i;
                        }
                    }
                }
            }

            int ostatecznyKoszt = dp[maxMask - 1];
            if (ostatecznyKoszt == int.MaxValue)
                return (0, new List<ScheduledTask>(), 0, 0);

            // === ODTWORZENIE HARMONOGRAMU ===
            var kolejnoscId = OdtworzKolejnosc(parent, n, zadania);

            List<ScheduledTask> harmonogram = new List<ScheduledTask>();
            int obecnyCzas = 0;

            foreach (int id in kolejnoscId)
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

            // === STOP POMIARU CZASU ===
            stopwatch.Stop();
            long timeTicks = stopwatch.ElapsedTicks;

            // === ZWRACAMY WYNIKI EKSPERYMENTALNE ===
            return (ostatecznyKoszt, harmonogram, timeTicks, dpStates);
        }

        private static List<int> OdtworzKolejnosc(
            int[] parent,
            int n,
            List<Zadanie> zadania)
        {
            List<int> kolejnoscId = new List<int>();
            int mask = (1 << n) - 1;

            while (mask > 0)
            {
                int index = parent[mask];
                if (index == -1) break;

                kolejnoscId.Add(zadania[index].Id);
                mask ^= (1 << index);
            }

            kolejnoscId.Reverse();
            return kolejnoscId;
        }
    }
}
