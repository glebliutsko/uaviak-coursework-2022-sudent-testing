using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    public class AddNumberConverter : IValueConverter
    {
        public int Term { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value + Term;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
