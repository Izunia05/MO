using System;
using System.Collections.Generic;

namespace Harmonogram_MO
{
    public class Heurystyka
    {
        public static (int koszt, List<ScheduledTask> harmonogram)
            Rozwiaz(List<PD_algo.Zadanie> zadania)
        {
            // 1. Kopiujemy listę, żeby nie psuć oryginału
            var posortowane = new List<PD_algo.Zadanie>(zadania);

            // 2. SORTOWANIE (EDD + kara)
            posortowane.Sort((a, b) =>
            {
                int porownanieTerminow = a.Termin.CompareTo(b.Termin);
                if (porownanieTerminow != 0) return porownanieTerminow;
                return b.Kara.CompareTo(a.Kara);
            });

            int obecnyCzas = 0;
            int calkowitaKara = 0;

            List<ScheduledTask> harmonogram = new List<ScheduledTask>();

            foreach (var z in posortowane)
            {
                int start = obecnyCzas;     // 🔹 zapamiętujemy start
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

            return (calkowitaKara, harmonogram);
        }
    }
}
