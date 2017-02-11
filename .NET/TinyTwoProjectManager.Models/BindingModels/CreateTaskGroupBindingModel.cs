using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class CreateTaskGroupBindingModel
    {
        public int? ParentTaskGroupId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}