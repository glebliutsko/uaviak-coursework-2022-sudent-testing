using System;

namespace StudentTesting.Application.Commands
{
    class RelayCommand : CommandBase
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
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