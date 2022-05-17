namespace StudentTesting.Application.Services.WindowDialog
{
    public interface IWindowDialogViewModel<T>
    {
        bool IsOk { get; }
        T Result { get; }
    }
}
