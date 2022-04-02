using System.Windows;

namespace StudentTesting.Application.Services
{
    public static class MessageBoxService
    {
        public static bool ConfirmActionMessageBox(string ask)
        {
            MessageBoxResult result = MessageBox.Show(ask, "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            return result == MessageBoxResult.OK;
        }

        public static void OkMessageBox(string description)
        {
            MessageBox.Show(description, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
