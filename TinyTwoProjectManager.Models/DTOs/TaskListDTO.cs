namespace TinyTwoProjectManager.Models
{
    public class TaskListDTO : DataTransferObject
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}