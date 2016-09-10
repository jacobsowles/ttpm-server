using System.Collections.Generic;

namespace TinyTwoProjectManager.Models
{
    public class TaskTableDTO
    {
        public IEnumerable<TaskTableTaskDTO> Tasks { get; set; }
    }
}