using System.Collections.Generic;

namespace TinyTwoProjectManager.Models
{
    public class ProjectListDTO
    {
        public IEnumerable<ProjectDTO> Projects { get; set; }
        public IEnumerable<TaskListDTO> TaskLists { get; set; }
        public IEnumerable<TaskDTO> Tasks { get; set; }
    }
}