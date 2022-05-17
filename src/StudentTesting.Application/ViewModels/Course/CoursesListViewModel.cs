using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Utils;
using StudentTesting.Application.Views.Course;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CoursesListViewModel : OnPropertyChangeBase
    {
        public CoursesListViewModel()
        {
            UpdateCource();

            AddCourceCommand = new RelayCommand(x => AddCource());
            OpenCourceCommand = new RelayCommand(x => OpenCource((DbModels.Course)x));
        }

        #region Command
        public ICommand AddCourceCommand { get; }
        public ICommand OpenCourceCommand { get; }
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
            new AddCourseWindowDialog(new AddCourseViewModel()).ShowDialog();
        }

        public void OpenCource(DbModels.Course course)
        {
            
        }
    }
}
