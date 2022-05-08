using System.Windows;

namespace StudentTesting.Application.Views
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        public ProgressWindow(string actionDiscription)
        {
            InitializeComponent();

            ActionDescriptionTextBlock.Text = actionDiscription;
        }
    }
}
