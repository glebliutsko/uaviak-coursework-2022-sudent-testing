using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Commands.Async;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services;
using StudentTesting.Application.Services.FileDialog;
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
                _selectedUser = value;

                EditableUser = SelectedUser == null
                    ? null
                    : new EditerUserViewModel(_db, _selectedUser, new OpenFileDialogService(), AskUserService.ConfirmActionMessageBox, UpdateUserCallback);

                OnPropertyChange();
            }
        }
        #endregion

        #region EditableUser
        private EditerUserViewModel _editableUser = null;
        public EditerUserViewModel EditableUser
        {
            get => _editableUser;
            set
            {
                _editableUser = value;
                OnPropertyChange();
                OnPropertyChange(nameof(IsVisibleUserEdit));
            }
        }
        #endregion

        #region IsVisibleUserEdit
        public bool IsVisibleUserEdit
        {
            get => EditableUser != null;
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
            EditableUser = new EditerUserViewModel(_db, new User(), new OpenFileDialogService(), AskUserService.ConfirmActionMessageBox, UpdateUserCallback, true);
        }
    }
}
