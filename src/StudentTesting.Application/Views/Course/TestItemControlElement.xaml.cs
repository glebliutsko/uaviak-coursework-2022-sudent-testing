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
    /// Логика взаимодействия для TestItemControlElement.xaml
    /// </summary>
    public partial class TestItemControlElement : UserControl
    {
        #region Title
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TestItemControlElement), new PropertyMetadata(null));
        #endregion

        #region Description
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TestItemControlElement), new PropertyMetadata(null));
        #endregion

        #region ClickCommand
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(TestItemControlElement), new PropertyMetadata(null));
        #endregion

        #region ClickCommandParameter
        public object ClickCommandParameter
        {
            get { return (object)GetValue(ClickCommandParameterProperty); }
            set { SetValue(ClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty ClickCommandParameterProperty =
            DependencyProperty.Register("ClickCommandParameter", typeof(object), typeof(TestItemControlElement), new PropertyMetadata(null));
        #endregion

        public TestItemControlElement()
        {
            InitializeComponent();
        }

        private void Root_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ClickCommand?.CanExecute(ClickCommandParameter) == true)
                ClickCommand.Execute(ClickCommandParameter);
        }
    }
}
