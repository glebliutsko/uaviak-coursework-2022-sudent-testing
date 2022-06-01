using StudentTesting.Application.Database;
using StudentTesting.Database.Models;

namespace StudentTesting.Application.UnitTest
{
    public static class CourseUnitTesting
    {
        public static bool InsertAndValidation(string title, string description, byte[] pic, int userId)
        {
            if (string.IsNullOrEmpty(title) || userId <= 0)
                return false;

            Course course;
            try
            {
                course = new Course { Title = title, Description = description, Picture = pic, OwnerCourceId = userId };
                DbContextKeeper.Saved.Courses.Add(course);
                DbContextKeeper.Saved.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            

            return course.Id != 0;
        }
    }
}
