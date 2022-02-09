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
        private int _countAttempts = 0;

        private readonly StudentDbContext _db;
        private readonly AuthorizeViewModel _viewModel;

        public AsyncCheckCredentialsCommand(AuthorizeViewModel viewModel, StudentDbContext db)
        {
            _db = db;
            _viewModel = viewModel;
        }

        private void ClearField(bool onlyPassword = true)
        {
            _viewModel.Password = "";
            if (!onlyPassword)
                _viewModel.Login = "";
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (string.IsNullOrEmpty(_viewModel.Login) || string.IsNullOrEmpty(_viewModel.Password))
            {
                _viewModel.ErrorMessage = "Заполните все поля";
                return;
            }

            var checker = await CheckerAuthorizeUser.SearchUserByLogin(_viewModel.Login, _db);
            if (checker == null || !checker.CheckPassword(_viewModel.Password))
            {
                _countAttempts++;
                _viewModel.ErrorMessage = "Неверный логин или пароль";
                ClearField();
                return;
            }

            ClearField(false);
            _viewModel.ErrorMessage = "";
            MessageBox.Show($"Логин: {checker.User.Login}\nФИО: {checker.User.FullName}\nРоль: {checker.User.Role}\nДокумент: {checker.User.DocumentNumber}");
        }
    }
}
