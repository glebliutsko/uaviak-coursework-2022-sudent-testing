using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.Authorize;
using StudentTesting.Application.Utils;
using StudentTesting.Application.ViewModels.Authorize;
using System;
using System.Threading.Tasks;

namespace StudentTesting.Application.Commands
{
    class AsyncCheckCredentialsCommand : AsyncCommandBase
    {
        private int _countAttempts = 0;

        private readonly AuthorizeViewModel _viewModel;
        private readonly IShowMainWindowService _showWindowService;
        private readonly IRequestCaptchaService _requestCaptchaService;
        private readonly Action _closeWindowAction;

        public AsyncCheckCredentialsCommand(AuthorizeViewModel viewModel,
                                            IShowMainWindowService showWindowService,
                                            IRequestCaptchaService requestCaptchaService,
                                            Action closeWindow)
        {
            _viewModel = viewModel;
            _showWindowService = showWindowService;
            _requestCaptchaService = requestCaptchaService;
            _closeWindowAction = closeWindow;
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
                ExcelLogs.ExcelLogsInstance.Value.AddLoginLog(_viewModel.Login, "Captcha", false);
                _viewModel.ErrorMessage = "Ошибка капчи";
                return;
            }

            var checker = await PasswordUserService.SearchUserByLogin(_viewModel.Login);
            if (checker == null || !checker.CheckPassword(_viewModel.Password))
            {
                ExcelLogs.ExcelLogsInstance.Value.AddLoginLog(_viewModel.Login, "Login", false);
                _countAttempts++;
                _viewModel.ErrorMessage = "Неверный логин или пароль";
                ClearField();
                return;
            }

            ExcelLogs.ExcelLogsInstance.Value.AddLoginLog(_viewModel.Login, "Login", true);

            ClearField(false);
            _viewModel.ErrorMessage = "";

            _showWindowService.ShowWindow(checker.User);
            _closeWindowAction();
        }
    }
}
