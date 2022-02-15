using StudentTesting.Application.ViewModels;

namespace StudentTesting.Application.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : ClosebleWindowBase
    {
        public CaptchaWindow(CaptchaViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
