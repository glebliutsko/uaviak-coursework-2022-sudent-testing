using StudentTesting.Application.Database;
using StudentTesting.Database.Models;

namespace StudentTesting.Application.UnitTest
{
    public static class UserUnitTesting
    {
        public static bool AddUser(string login, string fullname, string password, string document, UserRole? role)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(document) || role == null)
                return false;

            var user = new User { Login = login, PasswordHash = password, Role = role, FullName = fullname, DocumentNumber = document };
            DbContextKeeper.Saved.Users.Add(user);
            DbContextKeeper.Saved.SaveChanges();

            return user.Id != 0;
        }
    }
}
