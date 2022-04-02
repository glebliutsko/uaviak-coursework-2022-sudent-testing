using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StudentTesting.Application.Converter
{
    public class ImageEmptyConvertor : IValueConverter
    {
        public ImageSource PlaceholderImage { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? PlaceholderImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("OneWay converter");
        }
    }
}
