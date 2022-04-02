using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentTesting.Application.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для CircleImage.xaml
    /// </summary>
    public partial class CircleImage : UserControl
    {
        #region Source
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(CircleImage), new PropertyMetadata(null));
        #endregion

        public CircleImage()
        {
            InitializeComponent();
        }
    }
}
