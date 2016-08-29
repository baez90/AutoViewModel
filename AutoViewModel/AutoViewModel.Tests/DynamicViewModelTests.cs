using System;
using Moq;
using NUnit.Framework;

namespace AutoViewModel.Tests
{
    [TestFixture]
    public class DynamicViewModelTests
    {
        [Test]
        public void CallProxySetter_ShouldRaisePropertyChangedEvent()
        {
            var mock = new Mock<ICallableNotifyPropertyChanged>();
            mock.Setup(changed => changed.OnPropertyChanged(It.IsAny<string>())).Raises(changed => changed.PropertyChanged += null, EventArgs.Empty);
            var testPerson = ViewModelGenerator.CreateAutoViewModel<TestPerson>(mock.Object);
            testPerson.FirstName = "Hello World";
            mock.VerifyAll();
        }
    }

    public class TestPerson : SimpleNotifyPropertyChanged
    {
        public virtual string FirstName { get; set; }
    }
}