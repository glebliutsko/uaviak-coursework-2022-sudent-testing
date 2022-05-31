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
    }
}
