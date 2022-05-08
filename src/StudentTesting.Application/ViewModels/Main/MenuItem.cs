using System;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTesting.Application.ViewModels.Main
{
    public class MenuItem
    {
        private readonly Func<object, FrameworkElement> createContent;
        private readonly object viewModel;
        private FrameworkElement _content;

        public string Title { get; }
        public FrameworkElement Content => _content ??= createContent(viewModel);

        public MenuItem(string title, Func<object, FrameworkElement> createContent, object viewModel)
        {
            Title = title;
            this.createContent = createContent;
            this.viewModel = viewModel;
        }
    }
}
