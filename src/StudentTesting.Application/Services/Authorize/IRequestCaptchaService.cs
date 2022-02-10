using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTesting.Application.Services.Authorize
{
    public interface IRequestCaptchaService
    {
        public bool RequestCaptcha();
    }
}
