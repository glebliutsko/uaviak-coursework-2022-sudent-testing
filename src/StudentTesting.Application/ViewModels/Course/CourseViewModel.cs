using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using StudentTesting.Application.ViewModels.Test;
using StudentTesting.Application.Views.Test;
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
        private readonly DbModel.User _user;
        private readonly AddTestWindowDialogService _windowDialogService = new AddTestWindowDialogService();

        public CourseViewModel(DbModel.Course course, DbModel.User user)
        {
            _course = course;
            _user = user;
            CourseEditer = new CourseEditerViewModel(_course);
            CourseEditer.CourseChange += () => CourseChanged?.Invoke();

            RemoveCourseCommand = new RelayCommand(x => Remove());
            AddTestCommand = new RelayCommand(x => AddTest());
            OpenTestCommand = new RelayCommand(x => OpenTest((DbModel.Test)x));
            RemoveTestCommand = new RelayCommand(x => RemoveTest((DbModel.Test)x));
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
        public ICommand OpenTestCommand { get; }
        public ICommand RemoveTestCommand { get; }
        #endregion

        private void Remove()
        {
            DbContextKeeper.Saved.Remove(_course);
            DbContextKeeper.Saved.SaveChanges();

            CourseChanged?.Invoke();
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void OpenTest(DbModel.Test test)
        {
            var viewModel = new TestViewModel(test);
            viewModel.UpdateData();

            new TestWindow(viewModel).Show();
        }

        private void AddTest()
        {
            if (!_windowDialogService.Show())
                return;

            var result = _windowDialogService.Result;
            result.Course = _course;

            DbContextKeeper.Saved.Tests.Add(result);
            DbContextKeeper.Saved.SaveChanges();

            ExcelLogs.ExcelLogsInstance.Value.AddChangedLog(_user.Login, "Tests", "Add");

            UpdateData();
        }

        private void RemoveTest(DbModel.Test test)
        {
            if (MessageBoxService.ConfirmActionMessageBox("Удалить тест?"))
            {
                DbContextKeeper.Saved.Tests.Remove(test);
                DbContextKeeper.Saved.SaveChanges();
                ExcelLogs.ExcelLogsInstance.Value.AddChangedLog(_user.Login, "Remove", "Add");

                UpdateData();
            }    
        }

        public void UpdateData()
        {
            Tests = new ObservableCollection<DbModel.Test>(DbContextKeeper.Saved.Tests.Where(x => x.CourseId == _course.Id).ToList());
        }
    }
}
