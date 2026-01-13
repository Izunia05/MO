using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy_Backendu
{
    internal class PD_algo
    {
        public class Zadanie
        {
            public int Id { get; set; }
            public int Czas { get; set; }
            public int Termin { get; set; }
            public int Kara { get; set; }
        }

        public class PDalgo
        {
            public static int Rozwiaz(List<Zadanie> zadania)
            {
                int n = zadania.Count;
                int maxMask = 1 << n;

                int[] dp = new int[maxMask];       // minimalny koszt
                int[] czas = new int[maxMask];     // czas wykonania

                // inicjalizacja
                for (int i = 0; i < maxMask; i++)
                    dp[i] = int.MaxValue;

                dp[0] = 0; // brak zadań = brak kary

                // liczenie czasów
                for (int mask = 0; mask < maxMask; mask++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if ((mask & (1 << i)) != 0)
                            czas[mask] += zadania[i].Czas;
                    }
                }

                // właściwe DP
                for (int mask = 1; mask < maxMask; mask++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if ((mask & (1 << i)) != 0)
                        {
                            int poprzedniaMaska = mask ^ (1 << i);
                            int opoznienie = Math.Max(0, czas[mask] - zadania[i].Termin);
                            int koszt = dp[poprzedniaMaska] + opoznienie * zadania[i].Kara;

                            dp[mask] = Math.Min(dp[mask], koszt);
                        }
                    }
                }

                return dp[maxMask - 1];
            }
        }


    }

}
