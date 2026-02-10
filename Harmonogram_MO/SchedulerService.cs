using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonogram_MO 
{
    public static class SchedulerService
    {
        public static (int koszt, List<ScheduledTask> harmonogram, long czas, long operacje)
            UruchomDP(List<PD_algo.Zadanie> zadania)
        {
            return PD_algo.Rozwiaz(zadania);
        }

        public static (int koszt, List<ScheduledTask> harmonogram, long czas, long operacje1, long operacje2)
            UruchomBnB(List<PD_algo.Zadanie> zadania)
        {
            return BnB.Rozwiaz(zadania);
        }

        public static (int koszt, List<ScheduledTask> harmonogram, long czas, long operacje)
            UruchomHeurystyke(List<PD_algo.Zadanie> zadania)
        {
            return Heurystyka.Rozwiaz(zadania);
        }
    }
}

