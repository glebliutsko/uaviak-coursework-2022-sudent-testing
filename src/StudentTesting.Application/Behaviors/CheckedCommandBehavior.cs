using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace StudentTesting.Application.Behaviors
{
    public class CheckedCommandBehavior : Behavior<ToggleButton>
    {
        #region Command
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CheckedCommandBehavior), new PropertyMetadata(null));
        #endregion

        #region CommandParameter
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(CheckedCommandBehavior), new PropertyMetadata(null));
        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Checked += Checked;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Checked -= Checked;
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            if (Command?.CanExecute(CommandParameter) == true)
                Command.Execute(CommandParameter);
        }
    }
}
