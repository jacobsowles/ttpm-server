using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class CreateTaskBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }
    }
}