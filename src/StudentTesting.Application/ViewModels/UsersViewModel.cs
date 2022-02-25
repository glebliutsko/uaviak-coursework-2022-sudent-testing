using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services.FileDialog;
using StudentTesting.Application.Utils;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    public class EditableUser : OnPropertyChangeBase
    {
        public bool IsNewUser { get; }
        public User User { get; }

        public EditableUser()
        {
            IsNewUser = true;
            User = new User();
        }

        public EditableUser(User user)
        {
            IsNewUser = false;
            User = user;
        }

        #region IsEdit
        private bool _isEdit = false;
        public bool IsEdit
        {
            get => _isEdit;
            private set
            {
                if (_isEdit != value)
                {
                    _isEdit = value;
                    OnPropertyChange();
                }
            }
        }
        #endregion

        #region Role
        private UserRole? _role = null;
        public UserRole Role
        {
            get => _role ?? User.Role;

            set
            {
                _role = value;
                IsEdit = true;
                OnPropertyChange();
            }
        }
        #endregion

        #region Login
        private string _login = null;
        public string Login
        {
            get => _login ?? User.Login;
            set
            {
                _login = value;
                IsEdit = true;
                OnPropertyChange();
            }
        }
        #endregion

        #region FullName
        private string _fullName = null;
        public string FullName
        {
            get => _fullName ?? User.FullName;
            set
            {
                _fullName = value;
                IsEdit = true;
                OnPropertyChange();
            }
        }
        #endregion

        #region DocumentNumber
        private string _documentNumber = null;
        public string DocumentNumber
        {
            get => _documentNumber ?? User.DocumentNumber;
            set
            {
                _documentNumber = value;
                IsEdit = true;
                OnPropertyChange();
            }
        }
        #endregion

        #region UserPic
        private byte[] _userPic = null;
        public byte[] UserPic
        {
            get => _userPic ?? User.UserPic;
            set
            {
                _userPic = value;
                IsEdit = true;
                OnPropertyChange();
            }
        }
        #endregion

        public void Undo()
        {
            _role = null;
            OnPropertyChange(nameof(Role));

            _login = null;
            OnPropertyChange(nameof(Login));

            _fullName = null;
            OnPropertyChange(nameof(FullName));

            _documentNumber = null;
            OnPropertyChange(nameof(DocumentNumber));

            _userPic = null;
            OnPropertyChange(nameof(UserPic));

            IsEdit = false;
        }

        public bool Save()
        {
            if (!IsEdit)
                return false;

            // _user.Role = Role;
            User.Login = Login;
            User.FullName = FullName;
            User.DocumentNumber = DocumentNumber;
            User.UserPic = UserPic;

            Undo();
            return true;
        }
    }

    public class UsersViewModel : ViewModelBase
    {
        private readonly IFileDialogService _openUserPicDialog;
        private readonly Func<string, bool> _requestConfirm;

        public UsersViewModel(StudentDbContext db, IFileDialogService openUserPicDialog, Func<string, bool> requestConfirm)
            : base(db)
        {
            _openUserPicDialog = openUserPicDialog;
            _requestConfirm = requestConfirm;

            EditUserPicCommand = new RelayAsyncCommand(x => EditUserPic());
            SaveChangesUserCommand = new RelayAsyncCommand(x => SaveChangesUser());
            UndoChangesCommand = new RelayCommand(x => EditableUser?.Undo());
            RemoveUserCommand = new RelayAsyncCommand(x => RemoveUser());

            UpdateUsers();
        }

        #region Property
        #region Users
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region SelectedUser
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;

                EditableUser = _selectedUser == null ? null : new EditableUser(_selectedUser);

                OnPropertyChange();
                OnPropertyChange(nameof(IsVisibleUserEdit));
            }
        }
        #endregion

        #region EditableUser
        private EditableUser _editableUser = null;
        public EditableUser EditableUser
        {
            get => _editableUser;
            set
            {
                _editableUser = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region IsVisibleUserEdit
        public bool IsVisibleUserEdit
        {
            get => SelectedUser != null;
        }
        #endregion
        #endregion

        #region Command
        public IAsyncCommand EditUserPicCommand { get; }
        public IAsyncCommand SaveChangesUserCommand { get; }
        public IAsyncCommand RemoveUserCommand { get; }
        public ICommand UndoChangesCommand { get; }
        #endregion

        public static UserRole[] ListRoles => Enum.GetValues<UserRole>();

        private void UpdateUsers()
        {
            Users = new ObservableCollection<User>(_db.Users.ToList());
        }

        private async Task UpdateUsersAsync()
        {
            Users = new ObservableCollection<User>(await _db.Users.ToListAsync());
        }

        private async Task EditUserPic()
        {
            if (EditableUser == null)
                return;

            try
            {
                string filename = _openUserPicDialog.Show("Image Files|*.jpg;*.jpeg;*.png");
                EditableUser.UserPic = await File.ReadAllBytesAsync(filename);
            }
            catch (UserCancelSelectFileException)
            {
                return;
            }
        }

        private async Task SaveChangesUser()
        {
            if (!EditableUser.Save())
                return;

            await _db.SaveChangesAsync();
            await UpdateUsersAsync();
        }

        private async Task RemoveUser()
        {
            if (EditableUser.IsNewUser)
                return;

            if (!_requestConfirm($"Вы действительно хотите удалить пользователя {EditableUser.Login}?"))
                return;

            _db.Users.Remove(EditableUser.User);
            SelectedUser = null;
            await _db.SaveChangesAsync();

            await UpdateUsersAsync();
        }
    }
}
