using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using StudentTesting.Application.ViewModels.Test;
using StudentTesting.Application.Views.Test;
using System.Linq;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseStudentViewModel : CourseViewModel
    {
        public CourseStudentViewModel(DbModels.Course course, DbModels.User user) : base(course, user)
        {
            RemoveCourseCommand = null;
            AddTestCommand = null;
            RemoveTestCommand = null;
        }
        protected override void OpenTest(DbModels.Test test)
        {
            var viewModel = new TestStudentViewModel(test, this.user);
            viewModel.UpdateData();

            new TestStudentWindow(viewModel).Show();
        }

        protected override AttemptDTO[] LoadAttempt()
        {
            return DbContextKeeper.Saved.Attempts
                .Include(x => x.Test)
                .ThenInclude(x => x.Course)
                .Include(x => x.Student)
                .Include(x => x.Test)
                .ThenInclude(x => x.Questions)
                .Where(x => x.Test.Course == this.course && x.Student == this.user)
                .Select(x => AttemptDTO.FromDB(x))
                .ToArray();
        }
    }
}
