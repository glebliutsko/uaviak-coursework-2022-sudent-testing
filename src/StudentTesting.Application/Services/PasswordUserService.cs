using Microsoft.EntityFrameworkCore;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using StudentTesting.SecurityPassword;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StudentTesting.Application.Services
{
    public class PasswordUserService
    {
        public User User { get; private set; }
        private SaltedHash _userPasswordSaltedHash => new SaltedHash
        {
            Hash = User.PasswordHash,
            Salt = User.Salt
        };

        private readonly PasswordHasher _passwordHasher;
        private readonly StudentDbContext _db;

        public PasswordUserService(User user, StudentDbContext db)
        {
            _db = db;
            User = user;

            _passwordHasher = new PasswordHasher(SHA256.Create(), new RandomizedSaltGenerator(10));
        }

        public static async Task<PasswordUserService> SearchUserByLogin(string login, StudentDbContext db)
        {
            User user = await db.Users
                .Where(x => x.Login == login)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return new PasswordUserService(user, db);
        }

        public bool CheckPassword(string password) =>
            _passwordHasher.IsValidHash(password, _userPasswordSaltedHash);

        public async Task SetNewPassword(string newPassword)
        {
            SaltedHash saltedHash = _passwordHasher.ComputeSaltedHashWithRandomSalt(newPassword);
            User.PasswordHash = saltedHash.Hash;
            User.Salt = saltedHash.Salt;
            await _db.SaveChangesAsync();
        }
    }
}
