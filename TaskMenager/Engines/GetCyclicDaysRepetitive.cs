using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Engines
{
    public static class GetCyclicDaysRepetitive
    {
        public static List<string> GetCyclicDaysRepetitiveMethod()
        {
            List<string> result = new List<string>();
            int jump = 1;

            for (int i = 1; i < 100; i += jump)
            {
                if (i == 30)
                    jump = 5;
                else if (i == 45)
                    jump = 15;

                result.Add(i.ToString());
            }

            return result;
        }
    }
}
