using StudentTesting.Database.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    [ValueConversion(typeof(UserRole), typeof(string))]
    public class UserRoleConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var role = (UserRole)value;

            switch (role)
            {
                case UserRole.STUDENT:
                    return "Студент";
                case UserRole.TEACHER:
                    return "Преподаватель";
                default:
                    return role.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
