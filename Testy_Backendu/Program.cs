using System;
using System.Collections.Generic;
using Testy_Backendu;



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== URUCHAMIANIE TESTÓW HARMONOGRAMOWANIA ===");

        // ---------------------------------------------------------
        // TEST 1: Klasyczny przykład (Różne czasy i kary)
        // ---------------------------------------------------------
        Console.WriteLine("\n--- TEST 1: Podstawowy ---");

        var zadaniaTest1 = new List<PD_algo.Zadanie>
        {
            new PD_algo.Zadanie { Id = 1, Czas = 2, Termin = 8,  Kara = 10 },
            new PD_algo.Zadanie { Id = 2, Czas = 4, Termin = 10, Kara = 20 },
            new PD_algo.Zadanie { Id = 3, Czas = 3, Termin = 4,  Kara = 100 } // Krótki termin, duża kara!
        };

        UruchomTest(zadaniaTest1);


        // ---------------------------------------------------------
        // TEST 2: Dylemat (Zjeść ciastko czy mieć ciastko?)
        // ---------------------------------------------------------
        // Sytuacja: Mamy dwa zadania. 
        // Zadanie A (Id 10): Tanie, ale pilne.
        // Zadanie B (Id 20): Drogie, ale trochę mniej pilne.
        // Czas wykonania obu przekracza oba terminy. Co wybierze algorytm?
        Console.WriteLine("\n--- TEST 2: Trudny Wybór ---");

        var zadaniaTest2 = new List<PD_algo.Zadanie>
        {
            new PD_algo.Zadanie { Id = 10, Czas = 5, Termin = 6, Kara = 5 },   // Mała kara
            new PD_algo.Zadanie { Id = 20, Czas = 5, Termin = 7, Kara = 1000 } // Ogromna kara
        };
        // Spodziewany wynik: Algorytm powinien olać zadanie 10 (spóźnić je), 
        // żeby zadanie 20 zdążyło (lub spóźniło się minimalnie).
        // Kolejność powinna być: 20 -> 10.

        UruchomTest(zadaniaTest2);


        Console.WriteLine("\nNaciśnij dowolny klawisz, aby zamknąć...");
        Console.ReadKey();
    }

    // Metoda pomocnicza do wyświetlania wyników, żeby nie kopiować kodu
    static void UruchomTest(List<PD_algo.Zadanie> listaZadan)
    {
        Console.WriteLine("Dane wejściowe:");
        foreach (var z in listaZadan)
        {
            Console.WriteLine($" -> ID: {z.Id} | Czas: {z.Czas}h | Termin: {z.Termin}h | Kara: {z.Kara} PLN");
        }

        // --- WYWOŁANIE TWOJEGO ALGORYTMU ---
        try
        {
            var wynik = PD_algo.Rozwiaz(listaZadan);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWYNIK:");
            Console.WriteLine($"Minimalny Koszt Kar: {wynik.koszt} PLN");
            Console.Write($"Optymalna Kolejność ID: ");
            Console.WriteLine(string.Join(" -> ", wynik.kolejnosc));
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nBŁĄD: {ex.Message}");
            Console.ResetColor();
        }
    }
}