using StudentTesting.Application.ViewModels.Test;

namespace StudentTesting.Application.Views.Test
{
    /// <summary>
    /// Логика взаимодействия для AddTestWindowDialog.xaml
    /// </summary>
    public partial class AddTestWindowDialog : ClosebleWindowBase
    {
        public AddTestWindowDialog(AddTestViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
