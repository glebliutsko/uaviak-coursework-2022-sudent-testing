﻿using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using StudentTesting.Application.Views.Course;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CoursesListViewModel : OnPropertyChangeBase, IDataVisualizationViewModel
    {
        private readonly IWindowDialogService<DbModels.Course> newCourseService =
            new AddCourseWindowDialogService();

        protected readonly DbModels.User user;

        public CoursesListViewModel(DbModels.User user)
        {
            this.user = user;

            AddCourceCommand = new RelayCommand(x => AddCource());
            OpenCourseCommand = new RelayCommand(x => OpenCource((DbModels.Course)x), x => x != null);
        }

        #region Command
        public ICommand AddCourceCommand { get; protected set; }
        public ICommand OpenCourseCommand { get; protected set; }
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

        public void AddCource()
        {
            if (!newCourseService.Show())
                return;

            var newCourse = newCourseService.Result;
            newCourse.OwnerCourceId = user.Id;

            DbContextKeeper.Saved.Courses.Add(newCourseService.Result);
            DbContextKeeper.Saved.SaveChanges();

            UpdateData();
        }

        public void OpenCource(DbModels.Course course)
        {
            CourseViewModel viewModel = BuildViewModel(course);
            viewModel.UpdateData();
            viewModel.CourseChanged += UpdateData;

            new CourseWindow(viewModel).Show();
        }

        protected virtual CourseViewModel BuildViewModel(DbModels.Course course)
        {
            return new CourseViewModel(course, user);
        }

        public virtual void UpdateData()
        {
            Courses = new ObservableCollection<DbModels.Course>(DbContextKeeper.Saved.Courses.Where(x => x.OwnerCourceId == user.Id).ToList());
        }
    }
}
