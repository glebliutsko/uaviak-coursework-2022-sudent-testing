using StudentTesting.Application.Commands;
using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Services.Authorize;
using StudentTesting.Database;
using System;

namespace StudentTesting.Application.ViewModels
{
    public class AuthorizeViewModel : ViewModelBase, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;

        private readonly IShowMainWindowService _showWindowService;
        private readonly IRequestCaptchaService _requestCaptchaService;

        public AuthorizeViewModel(StudentDbContext db, IShowMainWindowService showWindowService = null, IRequestCaptchaService requestCaptchaService = null)
            : base(db)
        {
            _showWindowService = showWindowService ?? new ShowMainWindowService(db);
            _requestCaptchaService = requestCaptchaService ?? new ShowCapthaWindowService();

            CheckCredentialsCommand = new AsyncCheckCredentialsCommand(
                this,
                db,
                _showWindowService,
                _requestCaptchaService,
                () => OnRequestClose?.Invoke(this, new EventArgs())
            );
        }

        #region Property
        #region Login
        private string _login = "d.popova";  // TODO: Не забыть удалить этот логин.
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
        private string _password = "password";  // TODO: Не забыть удалить этот пароль.
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
