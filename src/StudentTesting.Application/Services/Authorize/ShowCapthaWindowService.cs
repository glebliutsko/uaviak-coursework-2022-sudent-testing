using StudentTesting.Application.ViewModels.Authorize;
using StudentTesting.Application.Views.Authorize;

namespace StudentTesting.Application.Services.Authorize
{
    public class ShowCapthaWindowService : IRequestCaptchaService
    {
        public bool RequestCaptcha()
        {
            var vm = new CaptchaViewModel();
            new CaptchaWindow(vm).ShowDialog();

            return vm.IsAccept;
        }
    }
}
