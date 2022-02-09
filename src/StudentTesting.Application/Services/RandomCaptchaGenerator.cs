using System;

namespace StudentTesting.Application.Services
{
    public class RandomCaptchaGenerator : ICaptchaGenerator
    {
        private Random _rnd = new Random();

        public string CaptchaText { get; set; }

        public bool CheckCaptcha(string userInput)
        {
            throw new NotImplementedException();
        }

        public void RegenerateCaptcha()
        {
            throw new NotImplementedException();
        }
    }
}
