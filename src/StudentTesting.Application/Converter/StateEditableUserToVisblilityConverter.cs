using StudentTesting.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    [ValueConversion(typeof(StateEditableUser), typeof(Visibility))]
    class StateEditableUserToVisblilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (StateEditableUser)value;
            return state == StateEditableUser.USER_CHANGED ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
