using System;

namespace StudentTesting.Application.Services.Captcha
{
    public class RandomStringGenerator : IStringGenerator
    {
        private static readonly char[] CAPTCHA_SYMVOLS =
        {
             'A', 'B', 'C', 'D', 'E', 'F',
             'G', 'H', 'I', 'J', 'K', 'L',
             'M', 'N', 'O', 'P', 'Q', 'R',
             'S', 'T', 'U', 'V', 'W', 'X',
             'Y', 'Z', '0', '1', '2', '3',
             '4', '5', '6', '7', '8', '9'
        };

        private Random _rnd = new Random();
        private int _lenght;

        public RandomStringGenerator(int lenght = 5)
        {
            _lenght = lenght;
        }

        public string String { get; private set; }

        public void GenerateString()
        {
            string captcha = "";
            for (int i = 0; i < _lenght; i++)
            {
                int indexSymvol = CAPTCHA_SYMVOLS.Length;
                captcha += CAPTCHA_SYMVOLS[_rnd.Next(indexSymvol)];
            }
            String = captcha;
        }
    }
}
