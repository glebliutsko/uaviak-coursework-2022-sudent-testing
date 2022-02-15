using StudentTesting.Application.ViewModels;

namespace StudentTesting.Application.Views.Windows
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
    }
}
