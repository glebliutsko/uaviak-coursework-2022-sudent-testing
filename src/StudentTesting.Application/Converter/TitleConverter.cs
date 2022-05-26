using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    public class TitleConverter : IValueConverter
    {
        public string Preffix { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{Preffix}: {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
