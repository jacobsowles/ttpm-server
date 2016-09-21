using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class TaskGroup : DatabaseTable
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
        

        public TaskGroup()
        {
            // TODO: Pull this dynamically
            UserId = "acaaa54a-927d-4915-9400-e87b1de31891";
        }
    }
}