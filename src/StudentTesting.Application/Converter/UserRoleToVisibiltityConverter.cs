using StudentTesting.Database.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    public class UserRoleToVisibiltityConverter : IValueConverter
    {
        public Visibility ValueIfStudent { get; set; }
        public Visibility ValueIfTeacher { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var role = (UserRole)value;
            switch (role)
            {
                case UserRole.STUDENT:
                    return ValueIfStudent;
                case UserRole.TEACHER:
                    return ValueIfTeacher;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
