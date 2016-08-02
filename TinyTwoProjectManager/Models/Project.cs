using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectListId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ProjectList ProjectList { get; set; }
        public virtual ICollection<TaskList> TaskLists { get; set; }
    }
}