using StudentTesting.Application.Commands;
using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Services.Authorize;
using StudentTesting.Application.Utils;
using System;

namespace StudentTesting.Application.ViewModels.Authorize
{
    public class AuthorizeViewModel : OnPropertyChangeBase, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;

        private readonly IShowMainWindowService _showWindowService;
        private readonly IRequestCaptchaService _requestCaptchaService;

        public AuthorizeViewModel(IShowMainWindowService showWindowService = null, IRequestCaptchaService requestCaptchaService = null)
        {
            _showWindowService = showWindowService ?? new ShowMainWindowService();
            _requestCaptchaService = requestCaptchaService ?? new ShowCapthaWindowService();

            CheckCredentialsCommand = new AsyncCheckCredentialsCommand(
                this,
                _showWindowService,
                _requestCaptchaService,
                () => OnRequestClose?.Invoke(this, new EventArgs())
            );
        }

        #region Property
        #region Login
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region Password
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region ErrorMessage
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChange();
            }
        }
        #endregion
        #endregion

        #region Command
        public IAsyncCommand CheckCredentialsCommand { get; }
        #endregion
    }
}
