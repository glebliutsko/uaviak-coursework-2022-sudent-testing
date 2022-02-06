namespace StudentTesting.Application.Commands
{
    abstract class ViewModelCommandBase<T> : CommandBase
    {
        protected readonly T viewModel;

        public ViewModelCommandBase(T viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
