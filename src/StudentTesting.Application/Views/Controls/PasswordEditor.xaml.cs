using StudentTesting.Application.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.Controls
{
    /// <summary>
    /// Interaction logic for PasswordEditor.xaml
    /// </summary>
    public partial class PasswordEditor : UserControl
    {
        #region Password
        public PasswordEditorViewModel Password
        {
            get { return (PasswordEditorViewModel)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(PasswordEditorViewModel), typeof(PasswordEditor), new PropertyMetadata(null));
        #endregion

        public PasswordEditor()
        {
            InitializeComponent();
        }
    }
}
