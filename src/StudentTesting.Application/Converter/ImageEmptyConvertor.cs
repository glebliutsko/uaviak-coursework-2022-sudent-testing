using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StudentTesting.Application.Converter
{
    public class ImageEmptyConvertor : IValueConverter
    {
        private static ImageSource _defaultImage = new BitmapImage(new Uri(@"pack://application:,,,/StudentTesting.Application;component/Resources/Images/DefaultUserPic.png"));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? _defaultImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
