using StudentTesting.Application.Database;
using StudentTesting.Application.Utils;
using StudentTesting.Application.ViewModels.Authorize;
using StudentTesting.Application.Views;
using StudentTesting.Application.Views.Authorize;
using System.IO;
using System.Reflection;
using System.Windows;

namespace StudentTesting.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private Configuration.Configuration _configuration;

        private string GetDefaultPathConfigurationFile()
        {
            var executablefile = new FileInfo(Assembly.GetEntryAssembly().Location);
            return Path.Join(executablefile.Directory.FullName, "configuration.json");
        }
        private bool ConnectDatabase()
        {
            return (_configuration.UsernameDatabase == null || _configuration.PasswordDatabase == null) switch
            {
                true => DbContextKeeper.ConnectionOpen(_configuration.AddressDatabase, _configuration.NameDatabase),
                false => DbContextKeeper.ConnectionOpen(_configuration.AddressDatabase, _configuration.UsernameDatabase, _configuration.PasswordDatabase, _configuration.NameDatabase)
            };
        }

        private bool InitilizeDatabase()
        {
            var progressWindow = new ProgressWindow("Подключение к MSSQL");
            progressWindow.Show();

            bool result = ConnectDatabase();

            progressWindow.Close();

            if (!result)
                MessageBox.Show("Ошибка подключения к БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            return result;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            _configuration = new Configuration.Configuration(GetDefaultPathConfigurationFile());

            if (!InitilizeDatabase())
            {
                Shutdown();
                return;
            }

            Current.MainWindow = new AuthorizeWindow(new AuthorizeViewModel());
            Current.MainWindow.Show();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DbContextKeeper.ConnectionClose();

            if (ExcelLogs.ExcelLogsInstance.IsValueCreated)
            {
                ExcelLogs.ExcelLogsInstance.Value.Save();
                ExcelLogs.ExcelLogsInstance.Value.Dispose();
            }
        }
    }
}
