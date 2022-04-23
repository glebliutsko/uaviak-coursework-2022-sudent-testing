using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    public class UsersViewModel : OnPropertyChangeBase
    {
        public UsersViewModel()
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
                if (value != null)
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

                UserInformationEditor = value == null
                    ? null
                    : new UserEditorViewModel(value, UpdateUsersAsync, UnselectUser);

                PasswordEditor = value == null
                    ? null
                    : new PasswordEditorViewModel(value);
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
        #endregion

        #region Command
        public ICommand AddNewUserCommand { get; }
        #endregion

        private void UpdateUsers()
        {
            Users = new ObservableCollection<User>(DbContextKeeper.Saved.Users.ToList());
        }

        private async Task UpdateUsersAsync()
        {
            Users = new ObservableCollection<User>(await DbContextKeeper.Saved.Users.ToListAsync());
        }

        private void UnselectUser()
        {
            SelectedUser = null;
            UserEditable = null;
        }

        private void AddNewUser()
        {
            SelectedUser = null;
            UserEditable = new User();
        }
    }
}
