namespace StudentTesting.Application.Services.WindowDialog
{
    public interface IWindowDialogService<T>
    {
        T Result { get; }

        public bool Show();
    }
}
