using StudentTesting.Application.Utils;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentTesting.Application.ViewModels
{
    public class EditableUser : OnPropertyChangeBase
    {
        public User User { get; }

        public EditableUser(User user)
        {
            User = user;
        }


        #region IsEdit
        private bool _isEdit = false;
        public bool IsEdit
        {
            get => _isEdit;
            private set
            {
                _isEdit = value;
                OnPropertyChange();
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
    }

    public class UsersViewModel : ViewModelBase
    {
        public UsersViewModel(StudentDbContext db)
            : base(db)
        {
            UpdateUsers();
        }

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
                this.EditableUser = new EditableUser(_selectedUser);

                OnPropertyChange();
                OnPropertyChange(nameof(IsVisibleUserEdit));
            }
        }
        #endregion

        #region EditableUser
        private EditableUser _editableUser;
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

        public UserRole[] ListRoles => Enum.GetValues<UserRole>();

        private void UpdateUsers()
        {
            Users = new ObservableCollection<User>(_db.Users.ToList());
        }
    }
}
