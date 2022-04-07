using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    public class NullConverter<T> : IValueConverter
    {
        public T ValueIfNull { get; set; }
        public T ValueIfNotNull { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? ValueIfNull : ValueIfNotNull;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class NullToBoolConverter : NullConverter<bool> { }

    public class NullToVisibilityConverter : NullConverter<Visibility> { }
}
