using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentTesting.Application.Views.Icons
{
    /// <summary>
    /// Логика взаимодействия для DeleteIcon.xaml
    /// </summary>
    public partial class DeleteIcon : UserControl
    {
        #region Color
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(DeleteIcon), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        #endregion

        public DeleteIcon()
        {
            InitializeComponent();
        }
    }
}
