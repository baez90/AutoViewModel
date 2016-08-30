using AutoViewModel.Interceptors;
using Castle.DynamicProxy;

namespace AutoViewModel
{
    public static class ViewModelGenerator
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static TModel CreateEmpty<TModel>() where TModel : class, ICallableNotifyPropertyChanged, new()
        {
            return CreateEmpty<TModel>(null);
        }

        internal static TModel CreateEmpty<TModel>(ICallableNotifyPropertyChanged parentHandler) where TModel : class, ICallableNotifyPropertyChanged, new()
        {
            var interceptor = new ViewModelSetterInterceptor();
            var proxy = Generator.CreateClassProxy<TModel>(interceptor);
            interceptor.Handler = parentHandler ?? proxy;
            return proxy;
        }
    }
}