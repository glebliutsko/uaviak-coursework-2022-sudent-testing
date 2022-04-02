using StudentTesting.Database;

namespace StudentTesting.Application.Tests
{
    public static class TestDbConnection
    {
        public static StudentDbContext GetDbContext()
        {
            return new StudentDbContext("10.0.0.2", "sa", "R1409p1209", "StudentTesting");
        }
    }
}
