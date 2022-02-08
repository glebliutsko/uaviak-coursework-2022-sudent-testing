using Microsoft.EntityFrameworkCore.Design;
using System;

namespace StudentTesting.Database
{
    public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
    {
        public StudentDbContext CreateDbContext(string[] args)
        {
            if (args.Length == 4)
                return new StudentDbContext(args[0], args[1], args[2], args[3]);
            else if (args.Length == 2)
                return new StudentDbContext(args[0], args[1]);

            throw new ArgumentException("2 or 4 arguments are accepted.");
        }
    }
}
