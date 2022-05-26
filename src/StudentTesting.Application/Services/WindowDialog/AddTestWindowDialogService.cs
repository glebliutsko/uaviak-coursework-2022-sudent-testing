using StudentTesting.Application.ViewModels.Test;
using StudentTesting.Application.Views.Test;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.Services.WindowDialog
{
    internal class AddTestWindowDialogService : IWindowDialogService<DbModel.Test>
    {
        public DbModel.Test Result { get; set; }

        public bool Show()
        {
            Result = null;

            var viewModel = new AddTestViewModel();
            var window = new AddTestWindowDialog(viewModel);

            window.ShowDialog();
            if (viewModel.IsOk)
                Result = viewModel.Result;
            return viewModel.IsOk;
        }
    }
}
