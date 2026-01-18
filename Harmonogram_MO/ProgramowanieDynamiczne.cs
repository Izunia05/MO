using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonogram_MO
{
    public class PD_algo
    {
        public class Zadanie
        {
            public int Id { get; set; }
            public int Czas { get; set; }     // Długość trwania zadania (Processing Time)
            public int Termin { get; set; }   // Deadline
            public int Kara { get; set; }     // Waga/Koszt za jednostkę spóźnienia
            // Usunąłem 'Priorytet', bo w tym algorytmie 'Kara' pełni tę funkcję.
        }

        public static (int koszt, List<int> kolejnosc) Rozwiaz(List<Zadanie> zadania)
        {
            int n = zadania.Count;
            int maxMask = 1 << n; // 2^n

            // Tablice DP
            int[] dp = new int[maxMask];       // minimalny koszt dla danego zbioru zadań
            int[] czas = new int[maxMask];     // łączny czas wykonania zadań w masce
            int[] parent = new int[maxMask];   // które zadanie dodaliśmy jako ostatnie, żeby tu dotrzeć

            // 1. Inicjalizacja
            for (int i = 0; i < maxMask; i++)
            {
                dp[i] = int.MaxValue; // Ustawiamy na nieskończoność
                czas[i] = 0;
            }

            dp[0] = 0;    // Stan początkowy: 0 zadań, 0 kosztu
            parent[0] = -1;

            // 2. Pre-kalkulacja czasów dla każdej maski
            // (To optymalizacja: obliczamy sumę czasów zadań w danym podzbiorze)
            for (int mask = 0; mask < maxMask; mask++)
            {
                for (int i = 0; i < n; i++)
                {
                    // Jeśli i-te zadanie jest w masce
                    if ((mask & (1 << i)) != 0)
                    {
                        czas[mask] += zadania[i].Czas;
                    }
                }
            }

            // 3. Właściwa pętla DP
            // Iterujemy po każdej możliwej masce (podzbiorze zadań)
            for (int mask = 1; mask < maxMask; mask++)
            {
                for (int i = 0; i < n; i++)
                {
                    // Sprawdzamy, czy zadanie 'i' należy do obecnego zbioru (maski)
                    if ((mask & (1 << i)) != 0)
                    {
                        int poprzedniaMaska = mask ^ (1 << i); // Stan bez zadania 'i'

                        // ZABEZPIECZENIE: Jeśli do poprzedniego stanu nie da się dojść, pomiń
                        if (dp[poprzedniaMaska] == int.MaxValue) continue;

                        // Obliczamy opóźnienie dla zadania 'i' zakładając, że robimy je na końcu tego zbioru
                        // Czas zakończenia to czas całej maski (bo zadania są upakowane bez przerw)
                        int czasZakonczenia = czas[mask];
                        int opoznienie = Math.Max(0, czasZakonczenia - zadania[i].Termin);

                        // Koszt to koszt poprzedniego stanu + kara za obecne zadanie
                        // Używamy 'long' na chwilę, aby uniknąć overflow przy dodawaniu, choć int powinien wystarczyć przy rozsądnych danych
                        long nowyKosztLong = (long)dp[poprzedniaMaska] + (long)opoznienie * zadania[i].Kara;

                        // Jeśli znaleźliśmy tańszą drogę do tego stanu (maski)
                        if (nowyKosztLong < dp[mask])
                        {
                            dp[mask] = (int)nowyKosztLong;
                            parent[mask] = i; // Zapisujemy, że doszliśmy tu wykonując zadanie 'i' jako ostatnie
                        }
                    }
                }
            }

            // 4. Odtwarzanie wyniku
            int ostatecznyKoszt = dp[maxMask - 1];

            // Jeśli koszt nadal wynosi MaxValue, coś poszło nie tak (np. brak zadań)
            if (ostatecznyKoszt == int.MaxValue) return (0, new List<int>());

            var kolejnosc = OdtworzKolejnosc(parent, n, zadania);
            return (ostatecznyKoszt, kolejnosc);
        }

        private static List<int> OdtworzKolejnosc(int[] parent, int n, List<Zadanie> zadania)
        {
            List<int> kolejnoscId = new List<int>();
            int mask = (1 << n) - 1; // Pełna maska (wszystkie bity 1)

            while (mask > 0)
            {
                int zadanieIndex = parent[mask];
                if (zadanieIndex == -1) break; // Zabezpieczenie

                // Dodajemy ID zadania (zamiast indeksu tablicy, co jest bardziej czytelne dla usera)
                kolejnoscId.Add(zadania[zadanieIndex].Id);

                // Usuwamy to zadanie z maski, cofając się do poprzedniego stanu
                mask ^= (1 << zadanieIndex);
            }

            kolejnoscId.Reverse(); // Odwracamy, bo szliśmy od końca
            return kolejnoscId;
        }
    }
}