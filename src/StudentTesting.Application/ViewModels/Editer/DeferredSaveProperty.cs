using StudentTesting.Application.Utils;
using System;

namespace StudentTesting.Application.ViewModels.Editer
{
    public class DeferredSaveProperty<TypeProperty> : OnPropertyChangeBase, IDeferredSaveProperty
    {
        private readonly Func<TypeProperty> _getValue;
        private readonly Action<TypeProperty> _setValue;
        private readonly Func<TypeProperty, bool> _checkValid;

        public DeferredSaveProperty(Func<TypeProperty> getValue, Action<TypeProperty> setValue, Func<TypeProperty, bool> checkValid = null)
        {
            IsModified = false;

            _getValue = getValue;
            _setValue = setValue;
            _checkValid = checkValid;
        }


        #region IsValid
        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            private set => SetProperty(ref _isValid, value);
        }
        #endregion

        #region IsModified
        private bool _isModified;
        public bool IsModified
        {
            get => _isModified;
            private set => SetProperty(ref _isModified, value);
        }
        #endregion

        #region Value
        private TypeProperty _modifiedValue = default;
        public TypeProperty Value
        {
            get => IsModified ? _modifiedValue : _getValue();
            set
            {
                _modifiedValue = value;
                IsModified = true;
                IsValid = _checkValid == null || _checkValid(value);
                OnPropertyChange();
            }
        }
        #endregion

        public bool Push()
        {
            if (!IsModified)
                return true;
            if (!IsValid)
                return false;

            _setValue(_modifiedValue);

            _modifiedValue = default;
            IsModified = false;
            IsValid = true;

            return true;
        }

        public void Clear()
        {
            _modifiedValue = default;
            IsModified = false;
            IsValid = true;
            OnPropertyChange(nameof(Value));
        }
    }
}
