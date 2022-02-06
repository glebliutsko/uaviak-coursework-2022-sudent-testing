using System;
using System.Security.Cryptography;
using System.Text;

namespace StudentTesting.SecurityPassword
{
    public class PasswordHasher
    {
        private readonly HashAlgorithm _hash;
        private readonly ISaltGenerator _saltGenerator;

        public PasswordHasher(HashAlgorithm hash, ISaltGenerator saltGenerator)
        {
            _hash = hash;
            _saltGenerator = saltGenerator;
        }

        private string ComputeHashForString(string s)
        {
            byte[] utf8String = Encoding.UTF8.GetBytes(s);
            byte[] stringHash = _hash.ComputeHash(utf8String);

            return Convert.ToHexString(stringHash);

        }

        private string ComputeHash(string password, string salt)
        {
            string passwordHashHex = ComputeHashForString(password);
            return ComputeHashForString(salt + passwordHashHex);
        }

        public SaltedHash ComputeSaltedHashWithRandomSalt(string password)
        {
            string salt = _saltGenerator.GenerateSalt();
            string saltedHashHex = ComputeHash(password, salt);

            return new SaltedHash
            {
                Hash = saltedHashHex,
                Salt = salt
            };
        }

        public bool IsValidHash(string password, SaltedHash hash)
        {
            string passwordHash = ComputeHash(password, hash.Salt);
            return hash.Hash.ToUpper() == passwordHash.ToUpper();
        }
    }
}