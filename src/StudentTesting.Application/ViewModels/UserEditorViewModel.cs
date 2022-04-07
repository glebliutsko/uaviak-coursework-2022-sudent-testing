using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.FileDialog;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    public partial class UserEditorViewModel : ViewModelBase
    {
        private readonly IFileDialogService _openUserPicDialog;
        private readonly Func<string, bool> _requestConfirm;
        private readonly Func<bool, Task> _userChanged;
        private User _user;

        public UserEditorViewModel(StudentDbContext db, User user, Func<bool, Task> userChanged) : base(db)
        {
            _openUserPicDialog = new OpenFileDialogService();
            _requestConfirm = MessageBoxService.ConfirmActionMessageBox;
            _userChanged = userChanged;
            _user = user;
            State = _db.Entry(_user).State == EntityState.Detached
                ? StateEditable.NEW
                : StateEditable.NOT_CHANGED;

            UndoChangesCommand = new RelayCommand(x => UndoChanges(), x => State != StateEditable.NOT_CHANGED);
            EditUserPicCommand = new RelayAsyncCommand(x => EditUserPic());
            RemoveUserCommand = new RelayAsyncCommand(x => Remove());
            SaveChangesUserCommand = new RelayAsyncCommand(x => SaveChanges(), x => State != StateEditable.NOT_CHANGED);
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

        #region Role
        private UserRole? _role = null;
        public UserRole Role
        {
            get => _role ?? _user.Role;
            set => SetUserProperty(ref _role, value);
        }
        #endregion

        #region Login
        private string _login = null;
        public string Login
        {
            get => _login ?? _user.Login;
            set => SetUserProperty(ref _login, value);
        }
        #endregion

        #region FullName
        private string _fullName = null;
        public string FullName
        {
            get => _fullName ?? _user.FullName;
            set => SetUserProperty(ref _fullName, value);
        }
        #endregion

        #region DocumentNumber
        private string _documentNumber = null;
        public string DocumentNumber
        {
            get => _documentNumber ?? _user.DocumentNumber;
            set => SetUserProperty(ref _documentNumber, value);
        }
        #endregion

        #region UserPic
        private byte[] _userPic = null;
        public byte[] UserPic
        {
            get => _userPic ?? _user.UserPic;
            set => SetUserProperty(ref _userPic, value);
        }
        #endregion

        #region ErrorMessage
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand UndoChangesCommand { get; }
        public IAsyncCommand EditUserPicCommand { get; }
        public IAsyncCommand RemoveUserCommand { get; }
        public IAsyncCommand SaveChangesUserCommand { get; }
        #endregion

        #region Action
        private void UndoChanges()
        {
            if (State == StateEditable.NOT_CHANGED)
                return;

            SetProperty(ref _role, null, nameof(Role));
            SetProperty(ref _login, null, nameof(Login));
            SetProperty(ref _fullName, null, nameof(FullName));
            SetProperty(ref _documentNumber, null, nameof(DocumentNumber));
            SetProperty(ref _userPic, null, nameof(UserPic));

            State = StateEditable.NOT_CHANGED;
        }

        private async Task EditUserPic()
        {
            try
            {
                string filename = _openUserPicDialog.Show("Image Files|*.jpg;*.jpeg;*.png");
                UserPic = await File.ReadAllBytesAsync(filename);
            }
            catch (UserCancelSelectFileException)
            {
                return;
            }
        }

        private async Task Remove()
        {
            if (State == StateEditable.NEW)
                return;

            if (!_requestConfirm($"Вы действительно хотите удалить пользователя {Login}?"))
                return;

            _db.Users.Remove(_user);
            await _db.SaveChangesAsync();
            await _userChanged(true);
        }

        private async Task SaveChanges()
        {
            if (State == StateEditable.NOT_CHANGED)
                return;

            if (new List<object> { Role, Login, FullName, DocumentNumber }.Any(x => x == null) ||
                new List<string> { Login, FullName, DocumentNumber }.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                ErrorMessage = "Заполните все поля";
                return;
            }

            _user.Role = Role;
            _user.Login = Login;
            _user.FullName = FullName;
            _user.DocumentNumber = DocumentNumber;
            _user.UserPic = UserPic;

            if (State == StateEditable.NEW)
                await _db.Users.AddAsync(_user);

            await _db.SaveChangesAsync();
            await _userChanged(false);

            ErrorMessage = null;
            State = StateEditable.NOT_CHANGED;
        }
        #endregion

        private bool SetUserProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
        {
            if (!SetProperty(ref member, value, propertyName))
                return false;

            if (State != StateEditable.NEW)
                State = StateEditable.CHANGED;
            return true;
        }
    }
}
