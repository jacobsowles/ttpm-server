using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class TaskList : DatabaseTable
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual Project Project { get; set; }
    }
}