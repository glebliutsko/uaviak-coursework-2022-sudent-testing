using Microsoft.EntityFrameworkCore;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System.Runtime.CompilerServices;

namespace StudentTesting.Application.ViewModels
{
    public class InformationTestEditorViewModel : ViewModelBase
    {
        private Test _test;
        public InformationTestEditorViewModel(StudentDbContext db, Test test) : base(db)
        {
            _test = test;
            State = _db.Entry(_test).State == EntityState.Detached
                ? StateEditable.NEW
                : StateEditable.NOT_CHANGED;
        }

        #region Property
        #region Title
        private string _title = null;
        public string Title
        {
            get => _title ?? _test.Title;
            set => SetUserProperty(ref _title, value);
        }
        #endregion

        #region Description
        private string _description = null;
        public string Description
        {
            get => _description ?? _test.Description;
            set => SetUserProperty(ref _description, value);
        }
        #endregion

        #region Picture
        private byte[] _picture = null;
        public byte[] Picture
        {
            get => _picture ?? _test.Picture;
            set => SetUserProperty(ref _picture, value);
        }
        #endregion

        #region Subject
        private Subject _subject = null;
        public Subject Subject
        {
            get => _subject ?? _test.Subject;
            set => SetUserProperty(ref _subject, value);
        }
        #endregion

        #region State
        private StateEditable _state;
        public StateEditable State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }
        #endregion
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
