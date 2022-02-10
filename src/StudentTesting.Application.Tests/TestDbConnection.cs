using StudentTesting.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
