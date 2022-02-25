using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTesting.Application.Services
{
    public static class AskUserService
    {
        public static bool ConfirmActionMessageBox(string ask)
        {
            MessageBoxResult result = MessageBox.Show(ask, "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            return result == MessageBoxResult.OK;
        }
    }
}
