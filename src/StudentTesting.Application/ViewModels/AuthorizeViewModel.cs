using StudentTesting.Application.Commands;
using StudentTesting.Application.Commands.Async;
using StudentTesting.Database;

namespace StudentTesting.Application.ViewModels
{
    class AuthorizeViewModel : ViewModelBase
    {
        public AuthorizeViewModel(StudentDbContext db)
            : base(db)
        {
            CheckCredentialsCommand = new AsyncCheckCredentialsCommand(this, db);
        }

        #region Property
        #region Login
        private string _login = "";
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
