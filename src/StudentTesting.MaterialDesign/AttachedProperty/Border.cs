using System.Windows;

namespace StudentTesting.MaterialDesign.AttachedProperty
{
    public class Border
    {
        public static CornerRadius GetBorderCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(BorderCornerRadiusProperty);
        }

        public static void SetBorderCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(BorderCornerRadiusProperty, value);
        }

        // Using a DependencyProperty as the backing store for BorderCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderCornerRadiusProperty =
            DependencyProperty.RegisterAttached("BorderCornerRadius", typeof(CornerRadius), typeof(Border), new PropertyMetadata(new CornerRadius(0)));
    }
}
