using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Task : DatabaseTable
    {
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