using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonogram_MO
{
    public class Heurystyka
    {
        public static (int koszt, List<int> kolejnosc) Rozwiaz(List<PD_algo.Zadanie> zadania)
        {
            // 1. Kopiujemy listę, żeby nie psuć oryginału
            var posortowane = new List<PD_algo.Zadanie>(zadania);

            // 2. SORTOWANIE (To jest serce algorytmu zachłannego)
            // Zasada: Najpierw te z najkrótszym terminem (Earliest Due Date).
            // Jeśli terminy są takie same, bierzemy to z większą karą.
            posortowane.Sort((a, b) =>
            {
                int porownanieTerminow = a.Termin.CompareTo(b.Termin);
                if (porownanieTerminow != 0) return porownanieTerminow;

                // Jeśli terminy równe, ważniejsza jest wyższa kara (malejąco)
                return b.Kara.CompareTo(a.Kara);
            });

            // 3. Obliczamy koszt dla takiej kolejności
            int obecnyCzas = 0;
            int calkowitaKara = 0;
            List<int> kolejnoscId = new List<int>();

            foreach (var z in posortowane)
            {
                obecnyCzas += z.Czas;
                int spoznienie = Math.Max(0, obecnyCzas - z.Termin);
                calkowitaKara += spoznienie * z.Kara;

                kolejnoscId.Add(z.Id);
            }

            return (calkowitaKara, kolejnoscId);
        }
    }
}