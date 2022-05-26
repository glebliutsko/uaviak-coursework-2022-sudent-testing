using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services.FileDialog;
using StudentTesting.Application.Services.WindowDialog;
using StudentTesting.Application.Utils;
using System;
using System.IO;
using System.Windows.Input;
using DBModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class AddCourseViewModel : OnPropertyChangeBase, IRequestCloseViewModel, IWindowDialogViewModel<DBModel.Course>
    {
        public event EventHandler OnRequestClose;

        private readonly IFileDialogService _openUserPicDialog;

        public bool IsOk { get; private set; } = false;
        public DBModel.Course Result { get; private set; }

        public AddCourseViewModel()
        {
            _openUserPicDialog = new OpenFileDialogService();

            SaveCommand = new RelayCommand(x => Save(), x => !string.IsNullOrEmpty(Title));
            ChangePictureCommand = new RelayCommand(x => ChangePicture());
        }

        #region Property
        #region Picture
        private byte[] _picture;
        public byte[] Picture
        {
            get => _picture;
            set => SetProperty(ref _picture, value);
        }
        #endregion

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
        public ICommand ChangePictureCommand { get; }
        #endregion

        private void ChangePicture()
        {
            try
            {
                string filename = _openUserPicDialog.Show("Image Files|*.jpg;*.jpeg;*.png");
                Picture = File.ReadAllBytes(filename);
            }
            catch (UserCancelSelectFileException)
            {
                return;
            }
        }

        private void Save()
        {
            Result = new DBModel.Course
            {
                Picture = Picture,
                Title = Title,
                Description = Description
            };
            IsOk = true;

            OnRequestClose?.Invoke(this, new EventArgs());
        }
    }
}
