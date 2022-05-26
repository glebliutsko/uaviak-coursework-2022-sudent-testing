using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Services.FileDialog;
using StudentTesting.Application.Utils;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DbModel = StudentTesting.Database.Models;

namespace StudentTesting.Application.ViewModels.Course
{
    public class CourseEditerViewModel : OnPropertyChangeBase
    {
        public event Action CourseChange;

        private DbModel.Course _course;
        private IFileDialogService _openUserPicDialog;

        public CourseEditerViewModel(DbModel.Course course)
        {
            State = StateEditable.NOT_CHANGED;
            _openUserPicDialog = new OpenFileDialogService();
            _course = course;

            EditPictureCommand = new RelayCommand(x => EditPicture());
            SaveCommand = new RelayCommand(x => SaveCourse());
            UndoCommand = new RelayCommand(x => Undo());
        }

        #region Property
        #region State
        private StateEditable _state;
        public StateEditable State
        {
            get => _state;
            private set => SetProperty(ref _state, value);
        }
        #endregion

        #region Title
        private string _title;
        public string Title
        {
            get => _title ?? _course.Title;
            set => SetCourseProperty(ref _title, value);
        }
        #endregion

        #region Description
        private string _description;
        public string Description
        {
            get => _description ?? _course.Description;
            set => SetCourseProperty(ref _description, value);
        }
        #endregion

        #region Picture
        private byte[] _picture;
        public byte[] Picture
        {
            get => _picture ?? _course.Picture;
            set => SetCourseProperty(ref _picture, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand EditPictureCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand UndoCommand { get; }
        #endregion

        private void SaveCourse()
        {
            _course.Title = Title;
            _course.Description = Description;
            _course.Picture = Picture;

            CourseChange?.Invoke();

            DbContextKeeper.Saved.SaveChanges();
            Undo();
        }

        private void Undo()
        {
            SetProperty(ref _title, null, nameof(Title));
            SetProperty(ref _description, null, nameof(Description));
            SetProperty(ref _picture, null, nameof(Picture));

            State = StateEditable.NOT_CHANGED;
        }

        private void EditPicture()
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

        private bool SetCourseProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
        {
            if (!SetProperty(ref member, value, propertyName))
                return false;

            if (State != StateEditable.NEW)
                State = StateEditable.CHANGED;
            return true;
        }
    }
}
