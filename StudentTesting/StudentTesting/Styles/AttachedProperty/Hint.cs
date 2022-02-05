using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTesting.Styles.AttachedProperty
{
    class Hint
    {
        public static readonly DependencyProperty HintTextProperty =
               DependencyProperty.RegisterAttached("HintText", typeof(string), typeof(Hint), new PropertyMetadata(""));

        public static string GetHintText(DependencyObject obj) => (string)obj.GetValue(HintTextProperty);
        public static void SetHintText(DependencyObject obj, string value) => obj.SetValue(HintTextProperty, value);
    }
}
