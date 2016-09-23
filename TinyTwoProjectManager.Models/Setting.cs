using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Setting : DatabaseTable
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserSetting> UserSettings { get; set; }
    }
}