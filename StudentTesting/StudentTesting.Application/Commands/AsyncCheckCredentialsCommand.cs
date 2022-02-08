using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Services;
using StudentTesting.Application.ViewModels;
using StudentTesting.Database;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTesting.Application.Commands
{
    class AsyncCheckCredentialsCommand : AsyncCommandBase
    {
        private readonly StudentDbContext _db;
        private readonly AuthorizeViewModel _viewModel;

        public AsyncCheckCredentialsCommand(AuthorizeViewModel viewModel, StudentDbContext db)
        {
            _db = db;
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) &&
                !string.IsNullOrEmpty(_viewModel.Login) &&
                !string.IsNullOrEmpty(_viewModel.Password);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var checker = await CheckerAuthorizeUser.SearchUserByLogin(_viewModel.Login, _db);
            if (checker == null || !checker.CheckPassword(_viewModel.Password))
                MessageBox.Show("Неверный логин или пароль!");

            MessageBox.Show($"Логин: {checker.User.Login}\nФИО: {checker.User.FullName}\nРоль: {checker.User.Role}\nДокумент: {checker.User.DocumentNumber}");
        }
    }
}
