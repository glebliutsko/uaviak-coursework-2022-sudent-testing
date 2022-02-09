using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTesting.Application.Services
{
    public interface ICaptchaGenerator
    {
        public string CaptchaText { get; }
        public bool CheckCaptcha(string userInput);
        public void RegenerateCaptcha();
    }
}
