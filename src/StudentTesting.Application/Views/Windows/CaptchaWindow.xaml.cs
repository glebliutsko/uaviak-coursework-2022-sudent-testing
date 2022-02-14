using StudentTesting.Application.ViewModels;
using System;
using System.Windows;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        private readonly CaptchaViewModel _viewModel;
        public CaptchaWindow(CaptchaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void OnRequestClose(object sender, EventArgs args) =>
            this.Close();

        private void Window_Closed(object sender, EventArgs e)
        {
            _viewModel.OnRequestClose -= OnRequestClose;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.OnRequestClose += OnRequestClose;
        }
    }
}
