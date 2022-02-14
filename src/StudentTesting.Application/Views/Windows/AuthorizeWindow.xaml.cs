using StudentTesting.Application.ViewModels;
using System;
using System.Windows;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        private readonly AuthorizeViewModel _viewModel;
        public AuthorizeWindow(AuthorizeViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void OnRequestClose(object sender, EventArgs args) =>
            this.Close();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.OnRequestClose += OnRequestClose;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _viewModel.OnRequestClose -= OnRequestClose;
        }
    }
}
