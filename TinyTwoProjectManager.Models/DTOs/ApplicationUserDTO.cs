using System.Collections.Generic;

namespace TinyTwoProjectManager.Models
{
    public class ApplicationUserDTO : DataTransferObject
    {
        public virtual ICollection<ProjectDTO> Projects { get; set; }
    }
}