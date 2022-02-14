using System.Windows;

namespace StudentTesting.Application.ViewModels
{
    public class MenuItem
    {
        public string Title { get; }
        public FrameworkElement Content { get; }

        public MenuItem(string title, FrameworkElement content)
        {
            Title = title;
            Content = content;
        }
    }
}
