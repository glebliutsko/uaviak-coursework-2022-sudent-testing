using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using System;
using System.Windows.Input;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Test
{
    public class AddTestViewModel : OnPropertyChangeBase, IRequestCloseViewModel, IWindowDialogViewModel<DbModel.Test>
    {
        public bool IsOk { get; private set; } = false;
        public DbModel.Test Result { get; private set; }

        public event EventHandler OnRequestClose;

        public AddTestViewModel()
        {
            SaveCommand = new RelayCommand(x => Save());
        }

        #region Property
        #region Title
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion

        #region Description
        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand SaveCommand { get; }
        #endregion

        private void Save()
        {
            Result = new DbModel.Test
            {
                Title = Title,
                Description = Description
            };
            IsOk = true;

            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
