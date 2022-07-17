using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Engines;

namespace TaskMenager.Converters
{
    internal class DurationInSecondsTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            if(int.TryParse(value.ToString(), out int temp))
            {
                return GetComunicateToAmountOfTime.GetComunicateToAmountOfTimeMethod(temp);
            }

            throw new InvalidDataException("Invalid data");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
