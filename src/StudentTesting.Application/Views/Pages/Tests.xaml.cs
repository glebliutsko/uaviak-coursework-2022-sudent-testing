using StudentTesting.Application.ViewModels;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Tests.xaml
    /// </summary>
    public partial class Tests : UserControl
    {
        public Tests(TestsViewModel testsViewModel)
        {
            DataContext = testsViewModel;

            InitializeComponent();
        }
    }
}
