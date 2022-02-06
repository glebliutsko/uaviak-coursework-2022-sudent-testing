using StudentTesting.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTesting.Application.Commands.Login
{
    class LoginCommand : ViewModelCommandBase<LoginViewModel>
    {
        public LoginCommand(LoginViewModel loginViewModel)
            : base(loginViewModel) { }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(viewModel.Login)
                && !string.IsNullOrEmpty(viewModel.Password);
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show($"{viewModel.Login}\n{viewModel.Password}");
        }
    }
}
