using StudentTesting.Application.Database;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.Linq;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseListStudentViewModel : CoursesListViewModel // Ооооооо да, костыли, мои любымы костыли. Ну а фигли до сдачи 11 часов.
    {
        public CourseListStudentViewModel(User user) : base(user)
        {
            AddCourceCommand = null;
        }

        public override void UpdateData()
        {
            Courses = new ObservableCollection<DbModels.Course>(DbContextKeeper.Saved.Courses.ToArray());
        }

        protected override CourseViewModel BuildViewModel(DbModels.Course course)
        {
            return new CourseStudentViewModel(course, this.user);
        }
    }
}
