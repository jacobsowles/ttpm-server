using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class TaskGroupDisplayOrder : Entity
    {
        [Required]
        public int TaskGroupId { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required]
        public int DisplayOrder { get; set; }


        public virtual TaskGroup TaskGroup { get; set; }

        public virtual Task Task { get; set; }
    }
}