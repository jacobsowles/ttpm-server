using NUnit.Framework;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Models.Extensions;

namespace TinyTwoProjectManager.Tests.Models.Extensions
{
    [TestFixture]
    public class ObjectExtensionTests
    {
        [Test]
        public void CopyPropertiesTo_ShouldCopyNonNullProperties()
        {
            GivenObjectWithPopulatedProperty();
            WhenObjectIsCopied();
            ThenPropertyValuesAreEqual();
        }

        [Test]
        public void CopyPropertiesTo_ShouldNotCopyNullProperties()
        {
            GivenObjectWitNullProperty();
            WhenObjectIsCopied();
            ThenPropertyValuesAreNotEqual();
        }

        #region Given

        private void GivenObjectWithPopulatedProperty()
        {
            _task = new Task
            {
                Name = "Task Name"
            };
        }

        private void GivenObjectWitNullProperty()
        {
            _task = new Task
            {
                Name = null
            };
        }

        #endregion

        #region When

        private void WhenObjectIsCopied()
        {
            _task.CopyPropertiesTo(_resultTask);
        }

        #endregion

        #region Then

        private void ThenPropertyValuesAreEqual()
        {
            Assert.AreEqual(_task.Name, _resultTask.Name);
        }

        private void ThenPropertyValuesAreNotEqual()
        {
            Assert.AreNotEqual(_task.Name, _resultTask.Name);
        }

        #endregion

        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _resultTask = new Task
            {
                Name = "Result Task Name"
            };
        }

        #endregion

        #region Private Members

        private Task _resultTask;
        private Task _task;

        #endregion
    }
}