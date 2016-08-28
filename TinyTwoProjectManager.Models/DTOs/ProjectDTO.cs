using System.Collections.Generic;

namespace TinyTwoProjectManager.Models
{
    public class ProjectDTO : DataTransferObject
    {
        public string Name { get; set; }

        public ICollection<TaskListDTO> TaskLists { get; set; }
    }
}