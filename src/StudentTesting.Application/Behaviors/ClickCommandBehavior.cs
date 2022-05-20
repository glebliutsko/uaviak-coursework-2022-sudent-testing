using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace StudentTesting.Application.Behaviors
{
    public class ClickCommandBehavior : Behavior<UIElement>
    {
        #region Command
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ClickCommandBehavior), new PropertyMetadata(null));
        #endregion

        #region CommandParameter
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(ClickCommandBehavior), new PropertyMetadata(null));
        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseUp += MouseUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseUp -= MouseUp;
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Command?.CanExecute(CommandParameter) == true)
                Command.Execute(CommandParameter);
        }
    }
}