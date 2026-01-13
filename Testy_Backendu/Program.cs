using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static Testy_Backendu.PD_algo;

namespace Testy_Backendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var zadania = new List<Zadanie>
{
            new Zadanie{ Id=1, Czas=3, Termin=4, Kara=10 },
            new Zadanie{ Id=2, Czas=2, Termin=3, Kara=5 },
            new Zadanie{ Id=3, Czas=4, Termin=6, Kara=8 }
};

            int wynik = PD_algo.PDalgo.Rozwiaz(zadania);
            foreach (var z in zadania)
            {
                Console.WriteLine($"Zadanie {z.Id}: Czas={z.Czas}, Termin={z.Termin}, Kara={z.Kara}");
            }

        }
    }
}
