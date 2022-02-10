using StudentTesting.Application.ViewModels;
using StudentTesting.Application.Views.Windows;

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
