using System.Linq;
using DbModels = StudentTesting.Database.Models;

namespace StudentTesting.Application.DTOModels
{
    public class AttemptDTO
    {
        public string CourseTitle { get; set; }
        public string TestTitle { get; set; }
        public string StudentName { get; set; }
        public int Score { get; set; }
        public int AllScore { get; set; }
        public int Mark => CalculateMark();

        public int CalculateMark()
        {
            float procent = (float)Score / AllScore;

            if (procent >= 0.85)
                return 5;
            else if (procent >= 0.65)
                return 4;
            else if (procent >= 0.4)
                return 3;
            else
                return 2;
        }

        public static AttemptDTO FromDB(DbModels.Attempt attempt)
        {
            return new AttemptDTO
            {
                CourseTitle = attempt.Test.Course.Title,
                TestTitle = attempt.Test.Title,
                StudentName = attempt.Student.FullName,
                Score = attempt.Score,
                AllScore = attempt.Test.Questions.Sum(x => x.Score)
            };
        }
    }
}
