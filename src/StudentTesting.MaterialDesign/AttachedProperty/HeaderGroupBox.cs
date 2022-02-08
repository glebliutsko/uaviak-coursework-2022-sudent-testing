using System.Windows;

namespace StudentTesting.MaterialDesign.AttachedProperty
{
    public static class HeaderGroupBox
    {
        #region HeaderAligment
        public static HorizontalAlignment GetHeaderAligment(DependencyObject obj) =>
            (HorizontalAlignment)obj.GetValue(HeaderAligmentProperty);

        public static void SetHeaderAligment(DependencyObject obj, HorizontalAlignment value) =>
            obj.SetValue(HeaderAligmentProperty, value);

        public static readonly DependencyProperty HeaderAligmentProperty =
            DependencyProperty.RegisterAttached("HeaderAligment", typeof(HorizontalAlignment), typeof(HeaderGroupBox), new PropertyMetadata(HorizontalAlignment.Left));
        #endregion

        #region HeaderFontSize
        public static double GetHeaderFontSize(DependencyObject obj) =>
            (double)obj.GetValue(HeaderFontSizeProperty);

        public static void SetHeaderFontSize(DependencyObject obj, double value) =>
            obj.SetValue(HeaderFontSizeProperty, value);

        // Using a DependencyProperty as the backing store for HeaderFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontSizeProperty =
            DependencyProperty.RegisterAttached("HeaderFontSize", typeof(double), typeof(HeaderGroupBox), new PropertyMetadata(16.0));
        #endregion
    }
}
