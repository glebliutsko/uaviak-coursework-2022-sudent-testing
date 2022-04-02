namespace StudentTesting.Application.Services.FileDialog
{
    public interface IFileDialogService
    {
        public string Show(string fileFilter, bool multiselect = false);
    }
}
