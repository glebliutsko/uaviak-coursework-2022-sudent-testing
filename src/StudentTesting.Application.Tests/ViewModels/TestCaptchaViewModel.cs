using NUnit.Framework;
using StudentTesting.Application.Services.Captcha;
using System.Windows.Media;

namespace StudentTesting.Application.Tests.ViewModels
{
    class FakeCapthaGenerator : ICapthaGenerator
    {
        public bool IsValidCaptcha { get; set; } = true;
        public int CountExecuteNewCapthca { get; set; } = 0;

        public int WidhtImage { get; set; }
        public int HeightImage { get; set; }

        public ImageSource CapthaImage { get; }

        public bool CheckCaptcha(string captcha)
        {
            return IsValidCaptcha;
        }

        public void NewCaptcha()
        {
            CountExecuteNewCapthca++;
        }
    }

    [TestFixture]
    class TestCaptchaViewModel
    {
        private FakeCapthaGenerator _capthaGenerator;

        [SetUp]
        public void SetUp()
        {
            _capthaGenerator = new FakeCapthaGenerator();
        }

        [Test]
        public void ValidCaptcha()
        {
            bool isCloseWindow = false;
            _capthaGenerator.IsValidCaptcha = true;
            var viewModel = new CaptchaViewModel(_capthaGenerator);
            viewModel.OnRequestClose += (s, e) => isCloseWindow = true;

            viewModel.CheckCaptchaCommand.Execute(null);

            Assert.IsTrue(viewModel.IsAccept);
            Assert.IsTrue(isCloseWindow);
        }

        [Test]
        public void InvalidCaptcha()
        {
            bool isCloseWindow = false;
            _capthaGenerator.IsValidCaptcha = false;
            var viewModel = new CaptchaViewModel(_capthaGenerator);
            viewModel.Answer = "Answer";
            viewModel.OnRequestClose += (s, e) => isCloseWindow = true;

            viewModel.CheckCaptchaCommand.Execute(null);

            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Answer));
            Assert.IsFalse(viewModel.IsAccept);
            Assert.IsFalse(isCloseWindow);
        }
    }
}
