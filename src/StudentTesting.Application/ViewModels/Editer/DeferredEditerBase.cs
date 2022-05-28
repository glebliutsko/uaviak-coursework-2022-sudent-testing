using StudentTesting.Application.Utils;
using System;
using System.ComponentModel;
using System.Linq;

namespace StudentTesting.Application.ViewModels.Editer
{
    public abstract class DeferredEditerBase : OnPropertyChangeBase
    {
        protected event EventHandler Pushed;
        protected event EventHandler Canceled;

        private readonly IDeferredSaveProperty[] _deferredProperties;

        protected DeferredEditerBase(IDeferredSaveProperty[] deferredProperties)
        {
            _deferredProperties = deferredProperties;
            foreach (var property in _deferredProperties)
            {
                property.PropertyChanged += DeferredPropertiesChange;
            }
        }

        private void DeferredPropertiesChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IDeferredSaveProperty.IsValid))
            {
                IsValid = _deferredProperties.All(x => x.IsValid);
            }
            if (e.PropertyName == nameof(IDeferredSaveProperty.IsModified))
            {
                _isModified = _deferredProperties.All(x => x.IsModified);
            }
        }

        #region IsValid
        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }
        #endregion

        #region IsModified
        private bool _isModified;
        public bool State
        {
            get => _isModified;
            set => SetProperty(ref _isModified, value);
        }
        #endregion

        public virtual void Push()
        {
            foreach (var property in _deferredProperties)
                property.Clear();

            Pushed?.Invoke(this, EventArgs.Empty);
        }

        public virtual void Clear()
        {
            foreach (var property in _deferredProperties)
                property.Clear();

            Canceled?.Invoke(this, EventArgs.Empty);
        }
    }
}
