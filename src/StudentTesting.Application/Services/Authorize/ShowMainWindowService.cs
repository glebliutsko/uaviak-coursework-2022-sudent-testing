using StudentTesting.Application.Views.Windows;
using StudentTesting.Database.Models;
using System.Windows;

namespace StudentTesting.Application.Services.Authorize
{
    class ShowMainWindowService : IShowMainWindowService
    {
        public void ShowWindow(User user)
        {
            new MainWindow(user).Show();
        }
    }
}
