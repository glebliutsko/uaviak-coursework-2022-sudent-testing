using System.Windows;

namespace StudentTesting.Application.Styles.AttachedProperty
{
    public static class ExecuteCommand
    {
        #region IsRunnung
        public static bool GetIsRunning(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsRunningProperty);
        }

        public static void SetIsRunning(DependencyObject obj, bool value)
        {
            obj.SetValue(IsRunningProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsRunning.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRunningProperty =
            DependencyProperty.RegisterAttached("IsRunning", typeof(bool), typeof(ExecuteCommand), new PropertyMetadata(false));
        #endregion

        #region ContentLoading
        public static object GetLoadingContent(DependencyObject obj)
        {
            return obj.GetValue(LoadingContentProperty);
        }

        public static void SetLoadingContent(DependencyObject obj, object value)
        {
            obj.SetValue(LoadingContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadingContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingContentProperty =
            DependencyProperty.RegisterAttached("LoadingContent", typeof(object), typeof(ExecuteCommand), new PropertyMetadata("Loading..."));
        #endregion
    }
}
