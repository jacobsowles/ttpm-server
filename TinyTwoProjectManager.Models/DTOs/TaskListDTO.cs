using System.Collections.Generic;

namespace TinyTwoProjectManager.Models
{
    public class TaskListDTO : DataTransferObject
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskDTO> Tasks { get; set; }
    }
}