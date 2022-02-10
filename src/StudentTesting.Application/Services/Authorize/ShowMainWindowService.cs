using StudentTesting.Database.Models;
using System.Windows;

namespace StudentTesting.Application.Services.Authorize
{
    class ShowMainWindowService : IShowMainWindowService
    {
        public void ShowWindow(User user)
        {
            MessageBox.Show($"Логин: {user.Login}\nФИО: {user.FullName}\nРоль: {user.Role}\nДокумент: {user.DocumentNumber}");
        }
    }
}
