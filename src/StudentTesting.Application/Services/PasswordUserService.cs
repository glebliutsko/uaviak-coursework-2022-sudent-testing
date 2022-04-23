using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Database;
using StudentTesting.Application.SecurityPassword;
using StudentTesting.Database.Models;
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

        public PasswordUserService(User user)
        {
            User = user;

            _passwordHasher = new PasswordHasher(SHA256.Create(), new RandomizedSaltGenerator(10));
        }

        public static async Task<PasswordUserService> SearchUserByLogin(string login)
        {
            User user = await DbContextKeeper.Saved.Users
                .Where(x => x.Login == login)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            return new PasswordUserService(user);
        }

        public bool CheckPassword(string password) =>
            _passwordHasher.IsValidHash(password, _userPasswordSaltedHash);

        public async Task SetNewPassword(string newPassword)
        {
            SaltedHash saltedHash = _passwordHasher.ComputeSaltedHashWithRandomSalt(newPassword);
            User.PasswordHash = saltedHash.Hash;
            User.Salt = saltedHash.Salt;
            await DbContextKeeper.Saved.SaveChangesAsync();
        }
    }
}
