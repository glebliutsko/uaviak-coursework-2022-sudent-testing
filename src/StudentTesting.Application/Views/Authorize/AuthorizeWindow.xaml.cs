using StudentTesting.Application.ViewModels.Authorize;

namespace StudentTesting.Application.Views.Authorize
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : ClosebleWindowBase
    {
        public AuthorizeWindow(AuthorizeViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoginTextBox.Focus();
        }
    }
}
