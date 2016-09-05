using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Project : DatabaseTable
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<TaskList> TaskLists { get; set; }

        public Project()
        {
            // TODO: Pull this dynamically
            UserId = "acaaa54a-927d-4915-9400-e87b1de31891";
        }
    }
}