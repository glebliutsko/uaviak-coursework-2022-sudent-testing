using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.FileDialog;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        public UsersViewModel(StudentDbContext db)
            : base(db)
        {
            AddNewUserCommand = new RelayCommand(x => AddNewUser());

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
                SetProperty(ref _selectedUser, value);
                UserEditable = value;
            }
        }
        #endregion

        #region UserEditable
        private User _userEditable;
        public User UserEditable
        {
            get => _userEditable;
            set
            {
                SetProperty(ref _userEditable, value);
                OnPropertyChange(nameof(IsVisibleUserEdit));

                UserInformationEditor = value == null
                    ? null
                    : new UserEditorViewModel(_db, value, new OpenFileDialogService(), MessageBoxService.ConfirmActionMessageBox, UpdateUserCallback);

                PasswordEditor = value == null
                    ? null
                    : new PasswordEditorViewModel(_db, value, MessageBoxService.OkMessageBox);
            }
        }
        #endregion

        #region UserInformationEditor
        private UserEditorViewModel _userInformationEditor = null;
        public UserEditorViewModel UserInformationEditor
        {
            get => _userInformationEditor;
            set => SetProperty(ref _userInformationEditor, value);
        }
        #endregion

        #region PasswordEditor
        private PasswordEditorViewModel _passwordEditor;
        public PasswordEditorViewModel PasswordEditor
        {
            get => _passwordEditor;
            set => SetProperty(ref _passwordEditor, value);
        }
        #endregion

        #region IsVisibleUserEdit
        public bool IsVisibleUserEdit
        {
            get => UserEditable != null;
        }
        #endregion
        #endregion

        #region Command
        public ICommand AddNewUserCommand { get; }
        #endregion

        private void UpdateUsers()
        {
            Users = new ObservableCollection<User>(_db.Users.ToList());
        }

        private async Task UpdateUsersAsync()
        {
            Users = new ObservableCollection<User>(await _db.Users.ToListAsync());
        }

        private async Task UpdateUserCallback(bool isUnselect)
        {
            if (isUnselect)
                SelectedUser = null;

            await UpdateUsersAsync();
        }

        private void AddNewUser()
        {
            SelectedUser = null;
            UserEditable = new User();
        }
    }
}
