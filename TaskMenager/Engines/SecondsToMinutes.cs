using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Engines
{
    public static class SecondsToMinutes
    {
        public static int SecondsToMinutesCalculation(int AmountOfTime)
        {
            return AmountOfTime <= 60 ? 0 : AmountOfTime % 60;
        }
    }
}
