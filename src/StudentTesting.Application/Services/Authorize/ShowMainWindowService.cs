using StudentTesting.Application.ViewModels;
using StudentTesting.Application.Views.Windows;
using StudentTesting.Database;
using StudentTesting.Database.Models;

namespace StudentTesting.Application.Services.Authorize
{
    class ShowMainWindowService : IShowMainWindowService
    {
        private StudentDbContext _db;

        public ShowMainWindowService(StudentDbContext db)
        {
            _db = db;
        }

        public void ShowWindow(User user)
        {
            var viewModel = new MainViewModel(_db, user);
            new MainWindow(viewModel).Show();
        }
    }
}
