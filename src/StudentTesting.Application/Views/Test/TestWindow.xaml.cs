using StudentTesting.Application.ViewModels.Test;
using System.Windows;

namespace StudentTesting.Application.Views.Test
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow(TestViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
