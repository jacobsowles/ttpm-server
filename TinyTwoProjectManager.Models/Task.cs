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

        public virtual TaskList TaskList { get; set; }
    }
}