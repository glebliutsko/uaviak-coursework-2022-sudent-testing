using StudentTesting.Application.Commands.Login;
using StudentTesting.Database;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private readonly StudentDbContext _db;

        public LoginViewModel(StudentDbContext db)
        {
            _db = db;
            LoginButtonCommand = new LoginCommand(this);
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
        #endregion

        #region Command
        public ICommand LoginButtonCommand { get; private set; }
        #endregion
    }
}
