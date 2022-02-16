using StudentTesting.Database;
using StudentTesting.Database.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentTesting.Application.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        public UsersViewModel(StudentDbContext db)
            : base(db)
        {
            Users = new ObservableCollection<User>(_db.Users.ToList());
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
    }
}
