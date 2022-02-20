using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility FalseValue { get; set; } = Visibility.Hidden;
        public Visibility TrueValue { get; set; } = Visibility.Visible;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (Visibility)value;
            return val == TrueValue;
        }
    }
}
