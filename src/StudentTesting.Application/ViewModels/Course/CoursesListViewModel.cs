using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CoursesListViewModel : OnPropertyChangeBase
    {
        private readonly IWindowDialogService<DbModels.Course> newCourseService =
            new AddCourseWindowDialogService();

        private readonly User _user;

        public CoursesListViewModel(DbModels.User user)
        {
            UpdateCource();

            AddCourceCommand = new RelayCommand(x => AddCource());
            OpenCourseCommand = new RelayCommand(x => OpenCource((DbModels.Course)x));
            _user = user;
        }

        #region Command
        public ICommand AddCourceCommand { get; }
        public ICommand OpenCourseCommand { get; }
        #endregion

        #region Property
        #region Courses
        private ObservableCollection<DbModels.Course> _courses;

        public ObservableCollection<DbModels.Course> Courses
        {
            get => _courses;
            set => SetProperty(ref _courses, value);
        }
        #endregion
        #endregion

        private void UpdateCource()
        {
            Courses = new ObservableCollection<DbModels.Course>(DbContextKeeper.Saved.Courses.ToList());
        }

        public void AddCource()
        {
            if (!newCourseService.Show())
                return;

            var newCourse = newCourseService.Result;
            newCourse.OwnerCourceId = _user.Id;

            DbContextKeeper.Saved.Courses.Add(newCourseService.Result);
            DbContextKeeper.Saved.SaveChanges();

            UpdateCource();
        }

        public void OpenCource(DbModels.Course course)
        {

        }
    }
}
