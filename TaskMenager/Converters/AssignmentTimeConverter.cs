using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Converters
{
    internal class AssignmentTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            string temp;

            try
            {
                temp = value.ToString();
            }
            catch(Exception)
            {
                return value;
            }

            int LengthOfAssignemntTimeInput = temp.Length;

            return LengthOfAssignemntTimeInput > 8 ? temp.Remove(LengthOfAssignemntTimeInput - 8, 8).Replace(" ", Environment.NewLine) : temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
