using NUnit.Framework;
using System.Collections.Generic;
using TinyTwoProjectManager.Models;
using System;
using System.Linq;

namespace TinyTwoProjectManager.Tests.Models
{
    [TestFixture]
    public class TaskGroupTests
    {
        [Test]
        public void AllAncestors_ShouldReturnItselfPlusListOfAllTaskGroupsAboveTheSpecifiedGroup()
        {
            // Given task groups
            WhenAncestorsRetreived();
            ThenReturnedTaskGroupIdsShouldBe(new[] { 3, 2, 1 });
        }

        [Test]
        public void AllAncestors_ShoulExcludeSelfWhenSpecified()
        {
            // Given task groups
            GivenIncludeSelf(false);
            WhenAncestorsRetreived();
            ThenReturnedTaskGroupIdsShouldBe(new[] { 2, 1 });
        }

        #region Given

        public void GivenIncludeSelf(bool includeSelf)
        {
            _includeSelf = includeSelf;
        }

        #endregion

        #region When

        public void WhenAncestorsRetreived()
        {
            _resultTaskGroups = _taskGroup.AllAncestors(_includeSelf);
        }

        #endregion

        #region Then

        public void ThenReturnedTaskGroupIdsShouldBe(int[] ids)
        {
            if (ids.Count() != _resultTaskGroups.Count())
            {
                Assert.Fail(String.Format("Test expected {0} IDs. Results returned {1}.", ids.Count(), _resultTaskGroups.Count()));
            }

            int i = 0;
            foreach (var id in _resultTaskGroups.Select(tg => tg.Id))
            {
                Assert.AreEqual(ids[i++], id);
            }
        }

        #endregion

        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _taskGroup = new TaskGroup
            {
                Id = 3,
                ParentTaskGroup = new TaskGroup
                {
                    Id = 2,
                    ParentTaskGroup = new TaskGroup
                    {
                        Id = 1,
                        ParentTaskGroup = null
                    }
                }
            };
        }

        #endregion

        #region Private Members

        private TaskGroup _taskGroup;
        private IEnumerable<TaskGroup> _resultTaskGroups;
        private bool _includeSelf = true;

        #endregion
    }
}