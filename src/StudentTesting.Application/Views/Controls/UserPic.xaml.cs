using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StudentTesting.Application.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserPic.xaml
    /// </summary>
    public partial class UserPic : UserControl
    {
        #region Image
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(UserPic), new PropertyMetadata(null));
        #endregion

        #region ClickCommand
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(UserPic), new PropertyMetadata(null));
        #endregion

        public UserPic()
        {
            InitializeComponent();
        }

        private void Root_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object parameter = null;

            if (ClickCommand != null && ClickCommand.CanExecute(parameter))
                ClickCommand.Execute(parameter);
        }
    }
}
