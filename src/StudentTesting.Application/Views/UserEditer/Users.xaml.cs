using StudentTesting.Application.ViewModels.UserEditer;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.UserEditer
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users(UsersViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
