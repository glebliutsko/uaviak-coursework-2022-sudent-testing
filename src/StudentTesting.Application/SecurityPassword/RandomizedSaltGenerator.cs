using System;
using System.Security.Cryptography;

namespace StudentTesting.Application.SecurityPassword
{
    public class RandomizedSaltGenerator : ISaltGenerator
    {
        private readonly RandomNumberGenerator _randomNumberGenerator;
        private readonly int _lenght;

        public RandomizedSaltGenerator(int lenght)
        {
            _randomNumberGenerator = RandomNumberGenerator.Create();
            _lenght = lenght;
        }

        public string GenerateSalt()
        {
            byte[] randomBytes = new byte[(int)Math.Ceiling(_lenght / 2.0)];
            _randomNumberGenerator.GetBytes(randomBytes);

            string randomHex = Convert.ToHexString(randomBytes);
            if (randomHex.Length > 10)
                randomHex = randomHex.Substring(0, 10);

            return randomHex;
        }
    }
}
