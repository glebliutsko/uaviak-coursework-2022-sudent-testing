using StudentTesting.Application.ViewModels;
using StudentTesting.Database.Models;
using System.Windows;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
