using StudentTesting.Application.ViewModels;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.Pages
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
