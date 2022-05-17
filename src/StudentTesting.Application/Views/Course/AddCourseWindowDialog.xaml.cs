using StudentTesting.Application.ViewModels.Course;
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
