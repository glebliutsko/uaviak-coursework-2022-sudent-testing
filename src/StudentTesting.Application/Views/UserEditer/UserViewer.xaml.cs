using StudentTesting.Database.Models;
using System.Windows;
using System.Windows.Controls;

namespace StudentTesting.Application.Views.UserEditer
{
    /// <summary>
    /// Логика взаимодействия для UserViewer.xaml
    /// </summary>
    public partial class UserViewer : UserControl
    {
        public User User
        {
            get => (User)GetValue(UserProperty);
            set => SetValue(UserProperty, value);
        }

        // Using a DependencyProperty as the backing store for User.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(User), typeof(UserViewer), new PropertyMetadata(null));

        public UserViewer()
        {
            InitializeComponent();
        }
    }
}
