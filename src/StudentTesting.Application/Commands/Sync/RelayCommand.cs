using System;

namespace StudentTesting.Application.Commands.Sync
{
    public class RelayCommand : CommandBase
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter) =>
            _canExecute == null || _canExecute(parameter);

        public override void Execute(object parameter) =>
            _execute(parameter);
    }
}
