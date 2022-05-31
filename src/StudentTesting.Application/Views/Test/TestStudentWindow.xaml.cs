using StudentTesting.Application.ViewModels.Test;
using System.Windows;

namespace StudentTesting.Application.Views.Test
{
    /// <summary>
    /// Interaction logic for TestStudentWindow.xaml
    /// </summary>
    public partial class TestStudentWindow : Window
    {
        public TestStudentWindow(TestStudentViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
