using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Project : DatabaseTable
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<TaskList> TaskLists { get; set; }
    }
}