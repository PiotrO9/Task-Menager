using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Converters
{
    internal class DurationInSecondsTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            int temp;

            if(int.TryParse(value.ToString(), out temp))
            {
                if(temp == 0)
                {
                    return "Brak przypisanego czasu na wykonanie zadania";
                }
                else if(temp < 0)
                {
                    return "Wystąpił błąd z wczytywanie czasu na wykonanie zadania";
                }
                else
                {

                }
            }
            else
            {
                throw new InvalidDataException("Invalid data");
            }

            return value; ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
