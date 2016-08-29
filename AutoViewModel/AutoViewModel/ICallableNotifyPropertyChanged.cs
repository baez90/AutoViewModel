using System.ComponentModel;

namespace AutoViewModel
{
    public interface ICallableNotifyPropertyChanged : INotifyPropertyChanged
    {
        void OnPropertyChanged(string propertyName);
    }
}