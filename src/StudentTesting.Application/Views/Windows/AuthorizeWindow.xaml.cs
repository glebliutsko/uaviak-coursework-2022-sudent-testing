using System.Windows;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        public AuthorizeWindow(object viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
