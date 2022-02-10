using StudentTesting.Application.Utils;
using StudentTesting.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentTesting.Application.ViewModels
{
    public abstract class ViewModelBase : OnPropertyChangeBase
    {
        protected readonly StudentDbContext _db;

        protected ViewModelBase(StudentDbContext db)
        {
            _db = db;
        }
    }
}
