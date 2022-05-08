using StudentTesting.Application.ViewModels.Course;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.Course
{
    /// <summary>
    /// Interaction logic for CourseUserControl.xaml
    /// </summary>
    public partial class CoursesListUserControl : UserControl
    {
        public CoursesListUserControl(CoursesListViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
