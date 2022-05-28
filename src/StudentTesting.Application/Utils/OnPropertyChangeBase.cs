using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StudentTesting.Application.Utils
{
    public class PropertyObserver
    {
        public PropertyObserver(string propertyName, Action action)
        {
            PropertyName = propertyName;
            Action = action;
        }

        public string PropertyName { get; }
        public Action Action { get; }
    }

    public abstract class OnPropertyChangeBase : INotifyPropertyChanged
    {
        private List<PropertyObserver> _propertyObservers = new List<PropertyObserver>();

        public OnPropertyChangeBase()
        {
            PropertyChanged += ProperyChangedHandler;
        }

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

        protected void AddPropertyObserver(PropertyObserver propertyObserver) =>
            _propertyObservers.Add(propertyObserver);

        protected void AddPropertyObserver(string propertyName, Action action) =>
            AddPropertyObserver(new PropertyObserver(propertyName, action));

        private void ProperyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            foreach (var observer in _propertyObservers)
            {
                if (observer.PropertyName == e.PropertyName)
                    observer.Action();
            }
        }
    }
}
