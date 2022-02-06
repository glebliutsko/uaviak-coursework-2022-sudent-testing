using System;

namespace StudentTesting.Database.InitalData
{
    class Program
    {
        static StudentDbContext GetDbContext()
        {
            Console.Write("Use integrated security? (1 - yes, 0 - no): ");
            int integratedSecurity = Convert.ToInt32(Console.ReadLine());

            Console.Write("IP: ");
            string address = Console.ReadLine();

            Console.Write("Database: ");
            string database = Console.ReadLine();

            if (integratedSecurity == 0)
            {
                Console.Write("User: ");
                string user = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                return new StudentDbContext(address, user, password, database);
            }

            return new StudentDbContext(address, database);
        }

        static void Main(string[] args)
        {
            StudentDbContext db = GetDbContext();

            Console.WriteLine("Add user");
            db.Users.AddRange(IntitalData.Users);

            Console.WriteLine("Add group");
            db.Groups.AddRange(IntitalData.Group);

            db.SaveChanges();
        }
    }
}
