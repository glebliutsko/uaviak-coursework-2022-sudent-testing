using StudentTesting.Application.Database;
using StudentTesting.Application.ViewModels;
using StudentTesting.Application.Views.Windows;
using System.Windows;

namespace StudentTesting.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var progressWindow = new ProgressWindow("Подключение к БД");
            progressWindow.Show();

            bool result = InitializeDatabase();

            progressWindow.Close();


            if (!result)
            {
                MessageBox.Show("Ошибка подключения к БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
                return;
            }
            Current.MainWindow = new AuthorizeWindow(new AuthorizeViewModel());
            Current.MainWindow.Show();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private static bool InitializeDatabase()
        {
            return Configuration.INTEGRATED_SECURITY switch
            {
                true => DbContextKeeper.ConnectionOpen(Configuration.ADDRESS_DB, Configuration.DATABASE),
                false => DbContextKeeper.ConnectionOpen(Configuration.ADDRESS_DB, Configuration.USER_DB, Configuration.PASSWORD_DB, Configuration.DATABASE)
            };
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DbContextKeeper.ConnectionClose();
        }
    }
}
