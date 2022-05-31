using StudentTesting.Application.ViewModels.Test;
using System.Windows;

namespace StudentTesting.Application.Views.Test
{
    /// <summary>
    /// Interaction logic for TestStudentWindow.xaml
    /// </summary>
    public partial class TestStudentWindow : ClosebleWindowBase
    {
        public TestStudentWindow(TestStudentViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
