using System;
using System.Windows.Input;
using AutoViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfTest.Models;

namespace WpfTest.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            NoProxyPerson = new Person();
            ProxyPerson = ViewModelGenerator.CreateAutoViewModel<Person>();

            RunDemoFillCommand = new RelayCommand(() =>
            {
                NoProxyPerson.FirstName = Guid.NewGuid().ToString();
                NoProxyPerson.LastName = Guid.NewGuid().ToString();
                ProxyPerson.FirstName = Guid.NewGuid().ToString();
                ProxyPerson.LastName = Guid.NewGuid().ToString();
            });
        }

        public Person NoProxyPerson { get; }

        public Person ProxyPerson { get; }

        public ICommand RunDemoFillCommand { get; }
    }
}