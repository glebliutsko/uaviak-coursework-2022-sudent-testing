using StudentTesting.Application.Commands.Sync;
using System.Threading.Tasks;

namespace StudentTesting.Application.Commands.Async
{
    abstract class AsyncCommandBase : CommandBase, IAsyncCommand
    {
        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChange();
                RaiseCanExecuteChanged();
            }
        }

        public abstract Task ExecuteAsync(object parameter);

        public override bool CanExecute(object parameter)
        {
            return !IsRunning;
        }

        public override async void Execute(object parameter)
        {
            if (IsRunning)
                return;

            IsRunning = true;
            await ExecuteAsync(parameter);
            IsRunning = false;
        }
    }
}
