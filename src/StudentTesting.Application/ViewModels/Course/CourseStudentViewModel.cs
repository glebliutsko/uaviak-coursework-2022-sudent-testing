using StudentTesting.Application.ViewModels.Test;
using StudentTesting.Application.Views.Test;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseStudentViewModel : CourseViewModel
    {
        public CourseStudentViewModel(DbModels.Course course) : base(course)
        {
            RemoveCourseCommand = null;
            AddTestCommand = null;
            RemoveTestCommand = null;
        }
        protected override void OpenTest(DbModels.Test test)
        {
            var viewModel = new TestStudentViewModel(test);
            viewModel.UpdateData();

            new TestStudentWindow(viewModel).Show();
        }
    }
}
