using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Services;
using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System;
using System.Threading.Tasks;

namespace StudentTesting.Application.ViewModels
{
    public class PasswordEditorViewModel : OnPropertyChangeBase
    {
        private readonly User _user;
        private readonly Action<string> _showSuccess;

        public PasswordEditorViewModel(User user)
        {
            _user = user;
            _showSuccess = MessageBoxService.OkMessageBox;

            UpdatePasswordCommand = new RelayAsyncCommand(x => UpdatePassword());
        }

        #region Property
        #region Password
        private string _password = "";
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        #endregion

        #region RepeatPassword
        private string _repeatPassword = "";
        public string RepeatPassword
        {
            get => _repeatPassword;
            set => SetProperty(ref _repeatPassword, value);
        }
        #endregion

        #region ErrorMessage
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        #endregion
        #endregion

        #region Command
        public IAsyncCommand UpdatePasswordCommand { get; }
        #endregion

        public async Task UpdatePassword()
        {
            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(RepeatPassword))
            {
                ErrorMessage = "Заполните все поля";
                return;
            }
            if (Password != RepeatPassword)
            {
                ErrorMessage = "Пароли не совпадают";
                return;
            }

            var _passwordService = new PasswordUserService(_user);
            await _passwordService.SetNewPassword(Password);

            Password = "";
            RepeatPassword = "";
            ErrorMessage = "";

            _showSuccess("Пароль успешно изменён.");
        }
    }
}
