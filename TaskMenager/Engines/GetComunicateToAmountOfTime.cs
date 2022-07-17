using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Engines
{
    public static class GetComunicateToAmountOfTime
    {
        public static string GetComunicateToAmountOfTimeMethod(int AmountOfTime)
        {
            if (AmountOfTime == 0)
            {
                return "Brak przypisanego czasu na wykonanie zadania";
            }
            else if (AmountOfTime < 0)
            {
                return "Wystąpił błąd z wczytywanie czasu na wykonanie zadania";
            }

            int CalculateFromSecondsTominutes = SecondsToMinutes.SecondsToMinutesCalculation(AmountOfTime);

            return CalculateFromSecondsTominutes == 0 ?
                "Czas na wykonanie zadania" + Environment.NewLine + AmountOfTime + " sekund" :
                "Czas na wykonanie zadania" + Environment.NewLine + CalculateFromSecondsTominutes + " minut";
        }
    }
}
