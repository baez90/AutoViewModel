using AutoViewModel.Interceptors;
using Castle.DynamicProxy;

namespace AutoViewModel
{
    public static class ViewModelGenerator
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static TModel CreateAutoViewModel<TModel>() where TModel : class, ICallableNotifyPropertyChanged, new()
        {
            return CreateAutoViewModel<TModel>(null);
        }

        public static TModel CreateAutoViewModel<TModel>(ICallableNotifyPropertyChanged parentHandler) where TModel : class, ICallableNotifyPropertyChanged, new()
        {
            var interceptor = new ViewModelSetterInterceptor();
            var proxy = Generator.CreateClassProxy<TModel>(interceptor);
            interceptor.Handler = parentHandler ?? proxy;
            return proxy;
        }
    }
}