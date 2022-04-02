using StudentTesting.Application.ViewModels;
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
