using StudentTesting.Application.ViewModels;
using StudentTesting.Application.Views.Windows;
using StudentTesting.Database;
using System.Linq;
using System.Windows;

namespace StudentTesting.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private StudentDbContext _db;

        private StudentDbContext GetDbContext()
        {
#pragma warning disable CS0162
            if (Configuration.INTEGRATED_SECURITY)
                return new StudentDbContext(Configuration.ADDRESS_DB, Configuration.DATABASE);
            else
                return new StudentDbContext(Configuration.ADDRESS_DB, Configuration.USER_DB, Configuration.PASSWORD_DB, Configuration.DATABASE);
#pragma warning restore CS0162 // Обнаружен недостижимый код
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            new MainWindow().Show();

            base.OnStartup(e);

            _db = GetDbContext();
            _db.Groups.FirstOrDefault();

            var loginWindow = new AuthorizeWindow
            {
                DataContext = new AuthorizeViewModel(_db)
            };
            loginWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _db.Dispose();
        }
    }
}
