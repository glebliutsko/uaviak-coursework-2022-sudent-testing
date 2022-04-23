using StudentTesting.Application.ViewModels;
using StudentTesting.Application.Views.Windows;
using StudentTesting.Database.Models;

namespace StudentTesting.Application.Services.Authorize
{
    class ShowMainWindowService : IShowMainWindowService
    {
        public void ShowWindow(User user)
        {
            var viewModel = new MainViewModel(user);

            System.Windows.Application.Current.MainWindow = new MainWindow(viewModel);
            System.Windows.Application.Current.MainWindow.Show();
        }
    }
}
