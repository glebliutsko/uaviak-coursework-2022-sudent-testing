using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTesting.Application.Services.Captcha
{
    public interface IStringGenerator
    {
        public string String { get; }
        public void GenerateString();
    }
}
