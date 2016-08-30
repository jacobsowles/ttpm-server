using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Project : DatabaseTable
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<TaskList> TaskLists { get; set; }

        public Project()
        {
            // TODO: Pull this dynamically
            UserId = "254576d5-e3d8-4d2b-8729-0bf42502e478";
        }
    }
}