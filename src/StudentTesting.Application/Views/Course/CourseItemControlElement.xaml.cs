using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentTesting.Application.Views.Course
{
    /// <summary>
    /// Interaction logic for CourseUserControl.xaml
    /// </summary>
    public partial class CourseItemControlElement : UserControl
    {
        #region ClickCommand
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(CourseItemControlElement), new PropertyMetadata(null));

        public object ClickCommandParameter
        {
            get { return (object)GetValue(ClickCommandParameterProperty); }
            set { SetValue(ClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandParameterProperty =
            DependencyProperty.Register("ClickCommandParameter", typeof(object), typeof(CourseItemControlElement), new PropertyMetadata(null));
        #endregion

        public CourseItemControlElement()
        {
            InitializeComponent();
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ClickCommand?.CanExecute(ClickCommandParameter) == true)
                ClickCommand.Execute(ClickCommandParameter);
        }
    }
}
