using System;
using System.Globalization;
using System.Windows.Data;

namespace GenderConverter
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return ((string)parameter == value.ToString());
                return (string)value == "Male";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : Binding.DoNothing;
        }
    }
}
