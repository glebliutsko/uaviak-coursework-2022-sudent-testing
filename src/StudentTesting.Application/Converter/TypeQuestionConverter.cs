using System;
using System.Globalization;
using System.Windows.Data;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.Converter
{
    public class TypeQuestionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: Аналогичная херня, как и UserRoleConverter.
            if (value is string)
                return value;

            var questionType = (DbModel.TypeQuestion)value;
            switch (questionType)
            {
                case DbModel.TypeQuestion.ONE_ANSWER:
                    return "Один ответ";
                case DbModel.TypeQuestion.MULTIPLE_ANSWER:
                    return "Несколько ответов";
                case DbModel.TypeQuestion.OPEN_ANSWER:
                    return "Открытый воп";
                default:
                    throw new ValueUnavailableException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
