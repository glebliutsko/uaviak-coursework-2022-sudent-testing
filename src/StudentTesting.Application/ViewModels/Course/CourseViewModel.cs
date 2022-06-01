using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.ExcelReport;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using StudentTesting.Application.ViewModels.Test;
using StudentTesting.Application.Views.Test;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseViewModel : OnPropertyChangeBase, IDataVisualizationViewModel, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;
        public event Action CourseChanged;

        protected readonly DbModel.Course course;
        protected readonly DbModel.User user;
        private readonly AddTestWindowDialogService _windowDialogService = new AddTestWindowDialogService();

        public CourseViewModel(DbModel.Course course, DbModel.User user)
        {
            this.course = course;
            this.user = user;
            CourseEditer = new CourseEditerViewModel(this.course);
            CourseEditer.CourseChange += () => CourseChanged?.Invoke();

            RemoveCourseCommand = new RelayCommand(x => Remove());
            AddTestCommand = new RelayCommand(x => AddTest());
            OpenTestCommand = new RelayCommand(x => OpenTest((DbModel.Test)x));
            RemoveTestCommand = new RelayCommand(x => RemoveTest((DbModel.Test)x));
            GetResultCommand = new RelayCommand(x => GetResults());
        }

        #region Property
        #region Course
        private CourseEditerViewModel _courseEditer;
        public CourseEditerViewModel CourseEditer
        {
            get => _courseEditer;
            protected set => SetProperty(ref _courseEditer, value);
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
        public ICommand RemoveCourseCommand { get; protected set; }
        public ICommand AddTestCommand { get; protected set; }
        public ICommand OpenTestCommand { get; }
        public ICommand RemoveTestCommand { get; protected set; }

        public ICommand GetResultCommand { get; }
        #endregion

        private void Remove()
        {
            DbContextKeeper.Saved.Remove(course);
            DbContextKeeper.Saved.SaveChanges();

            CourseChanged?.Invoke();
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OpenTest(DbModel.Test test)
        {
            var viewModel = new TestViewModel(test);
            viewModel.UpdateData();
            viewModel.TestChanged += () => UpdateData();

            new TestWindow(viewModel).Show();
        }

        private void AddTest()
        {
            if (!_windowDialogService.Show())
                return;

            var result = _windowDialogService.Result;
            result.Course = course;

            DbContextKeeper.Saved.Tests.Add(result);
            DbContextKeeper.Saved.SaveChanges();

            UpdateData();
        }

        private void RemoveTest(DbModel.Test test)
        {
            if (MessageBoxService.ConfirmActionMessageBox("Удалить тест?"))
            {
                DbContextKeeper.Saved.Tests.Remove(test);
                DbContextKeeper.Saved.SaveChanges();

                UpdateData();
            }
        }

        protected virtual void GetResults()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() != true)
                return;

            var attempts = LoadAttempt();

            ReportAttempt.GenerateReport(new FileInfo(dialog.FileName), attempts);
        }

        protected virtual AttemptDTO[] LoadAttempt()
        {
            return DbContextKeeper.Saved.Attempts
                .Include(x => x.Test)
                .ThenInclude(x => x.Course)
                .Include(x => x.Student)
                .Include(x => x.Test)
                .ThenInclude(x => x.Questions)
                .Where(x => x.Test.Course == course)
                .Select(x => AttemptDTO.FromDB(x))
                .ToArray();
        }

        public void UpdateData()
        {
            Tests = new ObservableCollection<DbModel.Test>(DbContextKeeper.Saved.Tests.Where(x => x.CourseId == course.Id).ToList());
        }
    }
}