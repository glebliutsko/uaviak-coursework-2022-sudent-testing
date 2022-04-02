using StudentTesting.Application.ViewModels;
using System;
using System.Windows;

namespace StudentTesting.Application.Views.Windows
{
    public class ClosebleWindowBase : Window
    {
        private readonly IRequestCloseViewModel _viewModel;

        public ClosebleWindowBase(IRequestCloseViewModel viewModel) : base()
        {
            _viewModel = viewModel;

            Closed += Window_Closed;
            Loaded += Window_Loaded;
        }

        private void OnRequestClose(object sender, EventArgs args) =>
            Close();

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
