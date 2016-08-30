using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoViewModel.Base
{
    public class SimpleNotifyPropertyChanged : ICallableNotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<TMember>(Expression<Func<TMember>> memberFunc)
        {
            var body = memberFunc?.Body as MemberExpression;
            var member = body?.Member as PropertyInfo;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member?.Name));
        }
    }
}