using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentTesting.Application.Views.Icons
{
    /// <summary>
    /// Логика взаимодействия для AddIcon.xaml
    /// </summary>
    public partial class AddIcon : UserControl
    {
        #region Color
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(AddIcon), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        #endregion
        public AddIcon()
        {
            InitializeComponent();
        }
    }
}
