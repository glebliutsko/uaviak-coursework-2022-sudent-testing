using StudentTesting.Application.ViewModels;
using StudentTesting.Application.Views.Windows;
using StudentTesting.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTesting.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
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
            base.OnStartup(e);

            var loginWindow = new LoginWindow
            {
                DataContext = new LoginViewModel(GetDbContext())
            };
            loginWindow.Show();
        }
    }
}
