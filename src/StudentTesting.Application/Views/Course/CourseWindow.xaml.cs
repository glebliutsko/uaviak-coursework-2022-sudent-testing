using StudentTesting.Application.ViewModels.Course;

namespace StudentTesting.Application.Views.Course
{
    /// <summary>
    /// Логика взаимодействия для CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : ClosebleWindowBase
    {
        public CourseWindow(CourseViewModel viewModel) : base(viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
