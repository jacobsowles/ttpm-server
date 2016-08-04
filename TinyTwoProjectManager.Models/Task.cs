using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TaskListId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool Complete { get; set; }

        public virtual TaskList TaskList { get; set; }
    }
}