using Castle.DynamicProxy;

namespace AutoViewModel.Interceptors
{
    internal class ViewModelSetterInterceptor : IInterceptor
    {
        internal ICallableNotifyPropertyChanged Handler { private get; set; }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            if (invocation.Method.Name.StartsWith("set_"))
            {   
                Handler.OnPropertyChanged(invocation.Method.Name.Replace("set_", string.Empty));
            }
        }
    }
}