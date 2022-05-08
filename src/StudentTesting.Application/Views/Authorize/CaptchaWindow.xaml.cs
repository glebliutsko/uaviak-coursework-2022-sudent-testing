using StudentTesting.Application.ViewModels.Authorize;

namespace StudentTesting.Application.Views.Authorize
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
