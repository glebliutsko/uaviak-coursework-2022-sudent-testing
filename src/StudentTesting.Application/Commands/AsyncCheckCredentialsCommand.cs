using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Services.Authorize;
using StudentTesting.Application.ViewModels;
using StudentTesting.Database;
using System.Threading.Tasks;

namespace StudentTesting.Application.Commands
{
    class AsyncCheckCredentialsCommand : AsyncCommandBase
    {
        private int _countAttempts = 0;

        private readonly StudentDbContext _db;
        private readonly AuthorizeViewModel _viewModel;
        private readonly IShowMainWindowService _showWindowService;
        private readonly IRequestCaptchaService _requestCaptchaService;

        public AsyncCheckCredentialsCommand(AuthorizeViewModel viewModel, StudentDbContext db, IShowMainWindowService showWindowService, IRequestCaptchaService requestCaptchaService)
        {
            _db = db;
            _viewModel = viewModel;
            _showWindowService = showWindowService;
            _requestCaptchaService = requestCaptchaService;
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

            if (_countAttempts >= 3 && !_requestCaptchaService.RequestCaptcha())
            {
                _viewModel.ErrorMessage = "Ошибка капчи";
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
            _showWindowService.ShowWindow(checker.User);
        }
    }
}
