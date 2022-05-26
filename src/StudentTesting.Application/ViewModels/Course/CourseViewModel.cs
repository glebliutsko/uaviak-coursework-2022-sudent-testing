using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseViewModel : OnPropertyChangeBase, IDataVisualizationViewModel, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;
        public event Action CourseChanged;

        private readonly DbModel.Course _course;
        private readonly AddTestWindowDialogService _windowDialogService = new AddTestWindowDialogService();

        public CourseViewModel(DbModel.Course course)
        {
            _course = course;
            CourseEditer = new CourseEditerViewModel(_course);
            CourseEditer.CourseChange += () => CourseChanged?.Invoke();

            RemoveCourseCommand = new RelayCommand(x => Remove());
            AddTestCommand = new RelayCommand(x => AddTest());
            RemoveTestCommand = new RelayCommand(x => RemoveTests((DbModel.Test)x));
        }

        #region Property
        #region Course
        private CourseEditerViewModel _courseEditer;
        public CourseEditerViewModel CourseEditer
        {
            get => _courseEditer;
            private set => SetProperty(ref _courseEditer, value);
        }
        #endregion

        #region Tests
        private ObservableCollection<DbModel.Test> _tests;
        public ObservableCollection<DbModel.Test> Tests
        {
            get => _tests;
            set => SetProperty(ref _tests, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand RemoveCourseCommand { get; }
        public ICommand AddTestCommand { get; }
        public ICommand RemoveTestCommand { get; }
        #endregion

        private void Remove()
        {
            DbContextKeeper.Saved.Remove(_course);
            DbContextKeeper.Saved.SaveChanges();

            CourseChanged?.Invoke();
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void AddTest()
        {
            if (!_windowDialogService.Show())
                return;

            var result = _windowDialogService.Result;
            result.Course = _course;

            DbContextKeeper.Saved.Tests.Add(result);
            DbContextKeeper.Saved.SaveChanges();

            UpdateData();
        }

        private void RemoveTests(DbModel.Test test)
        {
            if (MessageBoxService.ConfirmActionMessageBox("Удалить тест?"))
            {
                DbContextKeeper.Saved.Tests.Remove(test);
                DbContextKeeper.Saved.SaveChanges();

                UpdateData();
            }    
        }

        public void UpdateData()
        {
            Tests = new ObservableCollection<DbModel.Test>(DbContextKeeper.Saved.Tests.Where(x => x.CourseId == _course.Id).ToList());
        }
    }
}
