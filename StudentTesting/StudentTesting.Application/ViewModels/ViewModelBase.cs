using StudentTesting.Application.Utils;
using StudentTesting.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentTesting.Application.ViewModels
{
    abstract class ViewModelBase : OnPropertyChangeBase
    {
        protected readonly StudentDbContext _db;

        protected ViewModelBase(StudentDbContext db)
        {
            _db = db;
        }
    }
}
