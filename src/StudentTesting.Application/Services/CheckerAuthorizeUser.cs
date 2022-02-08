using Microsoft.EntityFrameworkCore;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using StudentTesting.SecurityPassword;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StudentTesting.Application.Services
{
    class CheckerAuthorizeUser
    {
        public User User { get; private set; }
        private readonly SaltedHash _passwordSaltedHash;

        private readonly PasswordHasher _passwordHasher;

        private CheckerAuthorizeUser(User user)
        {
            User = user;
            _passwordSaltedHash = new SaltedHash
            {
                Hash = User.PasswordHash,
                Salt = User.Salt
            };

            _passwordHasher = new PasswordHasher(SHA256.Create(), new RandomizedSaltGenerator(10));
        }

        public static async Task<CheckerAuthorizeUser> SearchUserByLogin(string login, StudentDbContext db)
        {
            User user = await db.Users
                .Where(x => x.Login == login)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return new CheckerAuthorizeUser(user);
        }

        public bool CheckPassword(string password) =>
            _passwordHasher.IsValidHash(password, _passwordSaltedHash);
    }
}
