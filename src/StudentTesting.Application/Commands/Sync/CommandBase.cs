using StudentTesting.Application.Utils;
using System;
using System.Windows.Input;

namespace StudentTesting.Application.Commands.Sync
{
    public abstract class CommandBase : OnPropertyChangeBase, ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);

        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
