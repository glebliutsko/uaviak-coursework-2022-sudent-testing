using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentTesting.Application.Utils
{
    public abstract class OnPropertyChangeBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(member, value))
                return false;

            member = value;
            OnPropertyChange(propertyName);
            return true;
        }

        protected virtual void OnPropertyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
