using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using StudentTesting.Application.Services.ExcelReport;
using StudentTesting.Application.Utils;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels.UserEditer
{
    public class UsersViewModel : OnPropertyChangeBase, IDataVisualizationViewModel
    {
        public UsersViewModel()
        {
            AddNewUserCommand = new RelayCommand(x => AddNewUser());

            ReportMarkStudentCommand = new RelayCommand(x => ReportMarkStudent());
            ReportDebtsStudentCommand = new RelayCommand(x => ReportDebtsStudent());
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
                    : new UserEditerViewModel(value, UpdateUsersAsync, UnselectUser);

                PasswordEditor = value == null
                    ? null
                    : new PasswordEditerViewModel(value);
            }
        }
        #endregion

        #region UserInformationEditor
        private UserEditerViewModel _userInformationEditor = null;
        public UserEditerViewModel UserInformationEditor
        {
            get => _userInformationEditor;
            set => SetProperty(ref _userInformationEditor, value);
        }
        #endregion

        #region PasswordEditor
        private PasswordEditerViewModel _passwordEditor;
        public PasswordEditerViewModel PasswordEditor
        {
            get => _passwordEditor;
            set => SetProperty(ref _passwordEditor, value);
        }
        #endregion
        #endregion

        #region Command
        public ICommand AddNewUserCommand { get; }
        public ICommand ReportMarkStudentCommand { get; }
        public ICommand ReportDebtsStudentCommand { get; }
        #endregion

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

        private void ReportMarkStudent()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() != true)
                return;

            var report = DbContextKeeper.Saved
                .Attempts
                .Include(x => x.Test)
                .ThenInclude(x => x.Course)
                .Include(x => x.Student)
                .Include(x => x.Test)
                .ThenInclude(x => x.Questions)
                .Where(x => x.Student == SelectedUser)
                .Select(x => AttemptDTO.FromDB(x))
                .ToArray();

            ReportAttempt.GenerateReport(new FileInfo(dialog.FileName), report);
        }

        private void ReportDebtsStudent()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() != true)
                return;

            ReportDebts.GenerateReport(new FileInfo(dialog.FileName), SelectedUser);
        }

        public void UpdateData()
        {
            Users = new ObservableCollection<User>(DbContextKeeper.Saved.Users.ToList());
        }
    }
}
