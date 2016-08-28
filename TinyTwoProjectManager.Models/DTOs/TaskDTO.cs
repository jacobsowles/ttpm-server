namespace TinyTwoProjectManager.Models
{
    public class TaskDTO : DataTransferObject
    {
        public int TaskListId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
    }
}