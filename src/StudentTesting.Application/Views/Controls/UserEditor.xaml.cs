using StudentTesting.Application.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.Controls
{
    public partial class UserEditor : UserControl
    {
        #region User
        public UserEditorViewModel User
        {
            get { return (UserEditorViewModel)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(UserEditorViewModel), typeof(UserEditor), new PropertyMetadata(null));
        #endregion

        public UserEditor()
        {
            InitializeComponent();
        }
    }
}
