using Microsoft.Win32;

namespace StudentTesting.Application.Services.FileDialog
{
    public class OpenFileDialogService : IFileDialogService
    {
        public string Show(string fileFilter, bool multiselect = false)
        {
            var dialog = new OpenFileDialog
            {
                Filter = fileFilter,
                Multiselect = multiselect
            };

            if (dialog.ShowDialog() != true)
                throw new UserCancelSelectFileException();

            return dialog.FileName;
        }
    }
}
