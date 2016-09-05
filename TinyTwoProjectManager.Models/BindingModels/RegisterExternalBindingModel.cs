using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}