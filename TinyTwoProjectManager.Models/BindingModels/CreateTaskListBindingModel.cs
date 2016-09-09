using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class CreateTaskListBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}