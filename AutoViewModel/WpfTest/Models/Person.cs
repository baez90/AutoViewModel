using AutoViewModel;

namespace WpfTest.Models
{
    public class Person : SimpleNotifyPropertyChanged
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }
    }
}