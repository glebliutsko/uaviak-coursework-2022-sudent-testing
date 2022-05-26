using NUnit.Framework;
using StudentTesting.Application.Services.Authorize;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System.Threading.Tasks;

namespace StudentTesting.Application.Tests.ViewModels
{
    class FakeShowMainWindowService : IShowMainWindowService
    {
        public int CountExecute { get; private set; } = 0;

        public void ShowWindow(User user) =>
            CountExecute++;
    }

    class FakeRequestCaptchaService : IRequestCaptchaService
    {
        public int CountExecute { get; private set; } = 0;
        public bool Answer { get; set; } = true;

        public bool RequestCaptcha()
        {
            CountExecute++;
            return Answer;
        }
    }

    [TestFixture]
    class TestAuthorizeViewModel
    {
        private StudentDbContext _db;
        private FakeRequestCaptchaService _requestCaptchaService;
        private FakeShowMainWindowService _showMainWindowService;

        public TestAuthorizeViewModel()
        {
            _db = TestDbConnection.GetDbContext();
        }

        [SetUp]
        public void SetUp()
        {
            _requestCaptchaService = new FakeRequestCaptchaService();
            _showMainWindowService = new FakeShowMainWindowService();
        }

        [Test]
        public async Task CheckEmptyPassword()
        {
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);
            viewModel.Login = "login";
            viewModel.Password = "";

            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.AreEqual(viewModel.ErrorMessage, "Заполните все поля");
        }

        [Test]
        public async Task CheckEmptyLogin()
        {
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);
            viewModel.Login = "";
            viewModel.Password = "password";

            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.AreEqual(viewModel.ErrorMessage, "Заполните все поля");
        }

        [Test]
        public async Task ValidCredentials()
        {
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);
            viewModel.Login = "d.popova";
            viewModel.Password = "password";

            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.IsTrue(string.IsNullOrEmpty(viewModel.ErrorMessage));
            Assert.AreEqual(_showMainWindowService.CountExecute, 1);
        }

        [Test]
        public async Task InvalidLogin()
        {
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);
            viewModel.Login = "invalid";
            viewModel.Password = "password";

            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.AreEqual(viewModel.ErrorMessage, "Неверный логин или пароль");
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Password));
            Assert.AreEqual(_requestCaptchaService.CountExecute, 0);
        }

        [Test]
        public async Task InvalidPassword()
        {
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);
            viewModel.Login = "d.popova";
            viewModel.Password = "invalid";

            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.AreEqual(viewModel.ErrorMessage, "Неверный логин или пароль");
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Password));
            Assert.AreEqual(_showMainWindowService.CountExecute, 0);
        }

        [Test]
        public async Task InvalidPassword3AndMore()
        {
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);

            for (int i = 0; i < 5; i++)
            {
                viewModel.Login = "d.popova";
                viewModel.Password = $"invalidpassword{i}";
                await viewModel.CheckCredentialsCommand.ExecuteAsync(null);
            }

            Assert.AreEqual(_requestCaptchaService.CountExecute, 2);
        }

        [Test]
        public async Task CaptchaCancel()
        {
            _requestCaptchaService.Answer = false;
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);

            for (int i = 0; i < 4; i++)
            {
                viewModel.Login = "d.popova";
                viewModel.Password = $"invalidpassword{i}";
                await viewModel.CheckCredentialsCommand.ExecuteAsync(null);
            }

            _requestCaptchaService.Answer = false;
            viewModel.Login = "d.popova";
            viewModel.Password = $"password";
            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.AreEqual(viewModel.ErrorMessage, "Ошибка капчи");
        }

        [Test]
        public async Task ValidCaptcha()
        {
            _requestCaptchaService.Answer = false;
            var viewModel = new AuthorizeViewModel(_db, _showMainWindowService, _requestCaptchaService);

            for (int i = 0; i < 4; i++)
            {
                viewModel.Login = "d.popova";
                viewModel.Password = $"invalidpassword{i}";
                await viewModel.CheckCredentialsCommand.ExecuteAsync(null);
            }

            _requestCaptchaService.Answer = true;
            viewModel.Login = "d.popova";
            viewModel.Password = $"password";
            await viewModel.CheckCredentialsCommand.ExecuteAsync(null);

            Assert.AreEqual(_showMainWindowService.CountExecute, 1);
        }
    }
}
