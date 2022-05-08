using StudentTesting.Application.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CoursesListViewModel : OnPropertyChangeBase
    {
        public CoursesListViewModel()
        {
            Courses = new ObservableCollection<DbModels.Course>();
            Courses.Add(new DbModels.Course { Title = "Математика", Description = "Тесты по математике. 2 класс. Иванова А.А.", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Русский язык", Description = "Тесты по русскому", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
            Courses.Add(new DbModels.Course { Title = "Геограия", Description = "Тесты по географии", Picture = null });
        }

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
    }
}
