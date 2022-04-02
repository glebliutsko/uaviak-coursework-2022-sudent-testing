using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentTesting.Application.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для CircleImageButton.xaml
    /// </summary>
    public partial class CircleImageButton : UserControl
    {
        #region Source
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(CircleImageButton), new PropertyMetadata(null));
        #endregion

        #region IconEditBackground
        public Brush IconEditBackground
        {
            get { return (Brush)GetValue(IconEditBackgroundProperty); }
            set { SetValue(IconEditBackgroundProperty, value); }
        }

        public static readonly DependencyProperty IconEditBackgroundProperty =
            DependencyProperty.Register("IconEditBackground", typeof(Brush), typeof(CircleImageButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0x55, 0x99, 0x99, 0x99))));
        #endregion

        #region ClickCommand
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(CircleImageButton), new PropertyMetadata(null));
        #endregion
        public CircleImageButton()
        {
            InitializeComponent();
        }

        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object parameter = null;

            if (ClickCommand != null && ClickCommand.CanExecute(parameter))
                ClickCommand.Execute(parameter);
        }
    }
}
