using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class TaskBindingModel
    {
        [Required]
        public int TaskListId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }
    }
}