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

            //if(LengthOfAssignemntTimeInput > 8)
            //{
            //    temp = temp.Remove(LengthOfAssignemntTimeInput - 8, 8);
            //    string[] SplitedString = temp.Split(' ');
            //    return SplitedString[0] + "&#x0d;&#x0a;" + SplitedString[1];
            //}
            //else
            //{
            //    return temp;
            //}

            return LengthOfAssignemntTimeInput > 8 ? temp.Remove(LengthOfAssignemntTimeInput - 8, 8).Replace(" ", Environment.NewLine) : temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
