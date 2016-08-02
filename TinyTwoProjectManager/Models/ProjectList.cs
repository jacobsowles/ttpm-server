using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class ProjectList
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}