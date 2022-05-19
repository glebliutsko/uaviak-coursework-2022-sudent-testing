using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseViewModel : OnPropertyChangeBase
    {
        #region Property
        #region Tests
        private ObservableCollection<DbModel.Test> _tests;

        public CourseViewModel()
        {
            Tests = new ObservableCollection<DbModel.Test>();
            Tests.Add(new Test
            {
                Title = "Квадратные уравнения",
                Description = "Повторение темы квадратных уравнений. Вычисление дискриминанта."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
            Tests.Add(new Test
            {
                Title = "Матрицы",
                Description = "Сложение и умножение матриц."
            });
        }

        public ObservableCollection<DbModel.Test> Tests
        {
            get => _tests;
            set => SetProperty(ref _tests, value);
        }
        #endregion
        #endregion
    }
}
