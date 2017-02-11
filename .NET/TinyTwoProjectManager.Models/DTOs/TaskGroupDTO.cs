using System.Collections.Generic;

namespace TinyTwoProjectManager.Models
{
    public class TaskGroupDTO : DataTransferObject
    {
        public string Name { get; set; }

        public int? ParentTaskGroupId { get; set; }
    }
}