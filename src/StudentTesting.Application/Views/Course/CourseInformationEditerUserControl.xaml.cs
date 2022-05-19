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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentTesting.Application.Views.Course
{
    /// <summary>
    /// Interaction logic for CourseEditorUserControl.xaml
    /// </summary>
    public partial class CourseInformationEditerUserControl : UserControl
    {
        #region Picture
        public ImageSource Picture
        {
            get { return (ImageSource)GetValue(PictureProperty); }
            set { SetValue(PictureProperty, value); }
        }

        public static readonly DependencyProperty PictureProperty =
            DependencyProperty.Register("Picture", typeof(ImageSource), typeof(CourseInformationEditerUserControl), new PropertyMetadata(null));
        #endregion

        #region Title
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(CourseInformationEditerUserControl), new PropertyMetadata(null));
        #endregion

        #region Description
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(CourseInformationEditerUserControl), new PropertyMetadata(null));
        #endregion

        #region ChangePictureCommand
        public ICommand ChangePictureCommand
        {
            get { return (ICommand)GetValue(ChangePictureCommandProperty); }
            set { SetValue(ChangePictureCommandProperty, value); }
        }

        public static readonly DependencyProperty ChangePictureCommandProperty =
            DependencyProperty.Register("ChangePictureCommand", typeof(ICommand), typeof(CourseInformationEditerUserControl), new PropertyMetadata(null));
        #endregion

        public CourseInformationEditerUserControl()
        {
            InitializeComponent();
        }
    }
}
