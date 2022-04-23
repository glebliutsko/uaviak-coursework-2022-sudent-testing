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

            bool result = Configuration.INTEGRATED_SECURITY switch
            {
                true => DbContextKeeper.ConnectionOpen(Configuration.ADDRESS_DB, Configuration.DATABASE),
                false => DbContextKeeper.ConnectionOpen(Configuration.ADDRESS_DB, Configuration.USER_DB, Configuration.PASSWORD_DB, Configuration.DATABASE)
            };

            if (!result)
            {
                MessageBox.Show("Ошибка подключения к БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
                return;
            }

            Current.MainWindow = new AuthorizeWindow(new AuthorizeViewModel());
            Current.MainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DbContextKeeper.ConnectionClose();
        }
    }
}
