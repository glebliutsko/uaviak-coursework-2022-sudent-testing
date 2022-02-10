using StudentTesting.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        private CaptchaViewModel _viewModel;
        public CaptchaWindow(CaptchaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void OnRequestClose(object sender, EventArgs args)
        {
            this.Close();
        }

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
