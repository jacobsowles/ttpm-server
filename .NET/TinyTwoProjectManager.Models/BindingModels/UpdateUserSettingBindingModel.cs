using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class UpdateUserSettingBindingModel
    {
        [Required]
        public int SettingId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}