using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class UserSetting : Entity
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int SettingId { get; set; }

        [Required]
        public string Value { get; set; }


        public virtual ApplicationUser User { get; set; }
        public virtual Setting Setting { get; set; }
    }
}