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
    }
}