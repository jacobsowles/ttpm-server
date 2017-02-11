using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class CreateTaskInGroupBindingModel
    {
        [Required]
        public int TaskGroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }
    }
}