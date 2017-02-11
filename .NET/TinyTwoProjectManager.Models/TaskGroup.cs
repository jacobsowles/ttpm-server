using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class TaskGroup : Entity
    {
        [Required]
        public string Name { get; set; }

        public int? ParentTaskGroupId { get; set; }

        [Required]
        public string UserId { get; set; }


        public virtual ApplicationUser User { get; set; }

        public virtual TaskGroup ParentTaskGroup { get; set; }

        public virtual ICollection<TaskGroup> TaskGroups { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<TaskGroupDisplayOrder> DisplayOrders { get; set; }

        public IEnumerable<TaskGroup> AllAncestors(bool includeSelf = true)
        {
            var ancestors = new List<TaskGroup>();

            if (includeSelf)
            {
                ancestors.Add(this);
            }

            if (ParentTaskGroup != null)
            {
                ancestors.AddRange(ParentTaskGroup.AllAncestors(true));
            }

            return ancestors;
        }
    }
}