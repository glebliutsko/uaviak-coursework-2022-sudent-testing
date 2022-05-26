using StudentTesting.Application.ViewModels.Course;
using StudentTesting.Application.Views.Course;
using DBModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.Services.WindowDialog
{
    public class AddCourseWindowDialogService : IWindowDialogService<DBModel.Course>
    {
        public DBModel.Course Result { get; private set; }

        public bool Show()
        {
            Result = null;

            var viewModel = new AddCourseViewModel();
            var window = new AddCourseWindowDialog(viewModel);

            window.ShowDialog();
            if (viewModel.IsOk)
                Result = viewModel.Result;
            return viewModel.IsOk;
        }
    }
}
