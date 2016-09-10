namespace TinyTwoProjectManager.Models
{
    public class TaskTableTaskDTO
    {
        public int Id { get; set; }
        public int TaskListId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
    }
}