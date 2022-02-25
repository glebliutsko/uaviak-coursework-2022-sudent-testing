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
            // TODO: Тут происходит какая-то хуйня.
            // Я хз как сюда может попадать строка при задании ComboBox.SelectItem = null
            // Я пытался это пофиксить по нормальному, но у меня не получилось, поэтому тут костыль.
            // ПОШЛО ОНО НАХУЙ, так работает и пофиг!!!
            if (value is string)
                return null;

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
            throw new NotSupportedException();
        }
    }
}
