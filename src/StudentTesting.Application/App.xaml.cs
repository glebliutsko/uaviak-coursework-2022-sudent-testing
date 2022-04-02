using Microsoft.Data.SqlClient;
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
            return Configuration.INTEGRATED_SECURITY
                ? new StudentDbContext(Configuration.ADDRESS_DB, Configuration.DATABASE)
                : new StudentDbContext(Configuration.ADDRESS_DB, Configuration.USER_DB, Configuration.PASSWORD_DB, Configuration.DATABASE);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                _db = GetDbContext();
                _db.Groups.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к БД\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
                return;
            }

            var loginWindow = new AuthorizeWindow(new AuthorizeViewModel(_db));
            loginWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _db.Dispose();
        }
    }
}
