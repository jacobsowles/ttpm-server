using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}