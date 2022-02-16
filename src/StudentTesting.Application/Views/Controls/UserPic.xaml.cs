using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentTesting.Application.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserPic.xaml
    /// </summary>
    public partial class UserPic : UserControl
    {
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(UserPic), new PropertyMetadata(null));

        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(double), typeof(UserPic), new PropertyMetadata(null));

        public UserPic()
        {
            InitializeComponent();
        }
    }
}
