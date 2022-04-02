using System;
using System.Threading.Tasks;

namespace StudentTesting.Application.Commands.Async
{
    public class RelayAsyncCommand : AsyncCommandBase
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Func<object, Task> _execute;

        public RelayAsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter)
                && (_canExecute == null || _canExecute(parameter));
        }

        public override Task ExecuteAsync(object parameter) =>
            _execute(parameter);
    }
}
