using static Harmonogram_MO.ProgramowanieDynamiczne;

namespace Harmonogram_MO
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            var zadania = new List<Zadanie>
{
            new Zadanie{ Id=1, Czas=3, Termin=4, Kara=10 },
            new Zadanie{ Id=2, Czas=2, Termin=3, Kara=5 },
            new Zadanie{ Id=3, Czas=4, Termin=6, Kara=8 }
};

            int wynik = ProgramowanieDynamiczne.PDalgo.Rozwiaz(zadania);
            Console.WriteLine("Minimalna kara: " + wynik);

        }
    }
}