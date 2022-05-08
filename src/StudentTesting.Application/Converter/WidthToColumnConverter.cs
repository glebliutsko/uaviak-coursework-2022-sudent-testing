using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    internal class WidthToColumnConverter : IValueConverter
    {
        public double MinColumn { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (double)value;
            var countColumn = (int)(width / MinColumn);
            return countColumn > 0 ? countColumn : 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
