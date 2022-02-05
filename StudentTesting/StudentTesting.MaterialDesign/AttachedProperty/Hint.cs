using System.Windows;

namespace StudentTesting.MaterialDesign.AttachedProperty
{
    public static class Hint
    {
        #region HintText
        public static readonly DependencyProperty HintTextProperty =
               DependencyProperty.RegisterAttached("HintText", typeof(string), typeof(Hint), new PropertyMetadata(""));

        public static string GetHintText(DependencyObject obj) =>
            (string)obj.GetValue(HintTextProperty);
        public static void SetHintText(DependencyObject obj, string value) =>
            obj.SetValue(HintTextProperty, value);
        #endregion
    }
}
