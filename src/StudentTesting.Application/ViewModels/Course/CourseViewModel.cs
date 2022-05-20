using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Database;
using StudentTesting.Application.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseViewModel : OnPropertyChangeBase, IDataVisualizationViewModel
    {
        public CourseViewModel(DbModel.Course course)
        {
            Course = course;
        }

        #region Property
        #region Course
        private DbModel.Course _course;
        public DbModel.Course Course
        {
            get => _course;
            set => SetProperty(ref _course, value);
        }
        #endregion
        #endregion

        public void UpdateData()
        {
            Course = DbContextKeeper.Saved.Courses.Include(x => x.Tests).FirstOrDefault(x => x.Id == Course.Id);
        }
    }
}
