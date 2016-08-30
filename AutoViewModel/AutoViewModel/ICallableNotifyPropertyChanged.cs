using System.ComponentModel;

namespace AutoViewModel
{
    public interface ICallableNotifyPropertyChanged : INotifyPropertyChanged
    {
        void RaisePropertyChanged(string propertyName);
    }
}