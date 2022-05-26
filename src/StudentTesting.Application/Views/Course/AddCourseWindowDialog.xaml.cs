using StudentTesting.Application.ViewModels.Course;

namespace StudentTesting.Application.Views.Course
{
    /// <summary>
    /// Interaction logic for AddCourceWindowDialog.xaml
    /// </summary>
    public partial class AddCourseWindowDialog : ClosebleWindowBase
    {
        public AddCourseWindowDialog(AddCourseViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
