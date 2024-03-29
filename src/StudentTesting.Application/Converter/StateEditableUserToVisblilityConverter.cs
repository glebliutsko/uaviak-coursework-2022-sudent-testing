﻿using StudentTesting.Application.ViewModels.Editer;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudentTesting.Application.Converter
{
    [ValueConversion(typeof(StateEditable), typeof(Visibility))]
    class StateEditableUserToVisblilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (StateEditable)value;
            return state == StateEditable.CHANGED ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
