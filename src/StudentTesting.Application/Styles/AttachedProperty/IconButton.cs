using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentTesting.Application.Styles.AttachedProperty
{
    public static class IconButton
    {
        #region IconSource
        public static ImageSource GetIconSource(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(IconSourceProperty);
        }

        public static void SetIconSource(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(IconSourceProperty, value);
        }

        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.RegisterAttached("IconSource", typeof(ImageSource), typeof(Button), new PropertyMetadata(null));
        #endregion
    }
}
