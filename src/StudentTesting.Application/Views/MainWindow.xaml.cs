using StudentTesting.Application.ViewModels.Main;

namespace StudentTesting.Application.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ClosebleWindowBase
    {
        public MainWindow(MainViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
