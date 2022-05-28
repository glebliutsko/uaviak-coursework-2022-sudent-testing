using System.ComponentModel;

namespace StudentTesting.Application.ViewModels.Editer
{
    public interface IDeferredSaveProperty : INotifyPropertyChanged
    {
        bool IsModified { get; }
        bool IsValid { get; }

        void Clear();
        bool Push();
    }
}