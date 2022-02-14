using StudentTesting.Database.Models;
using System.Windows;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user;
        public MainWindow(User user)
        {
            _user = user;

            InitializeComponent();

            UserView.User = _user;
        }
    }
}
