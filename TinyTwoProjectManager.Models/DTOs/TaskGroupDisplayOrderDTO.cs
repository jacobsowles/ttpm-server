namespace TinyTwoProjectManager.Models
{
    public class TaskGroupDisplayOrderDTO : DataTransferObject
    {
        public int TaskGroupId { get; set; }
        public int TaskId { get; set; }
        public int DisplayOrder { get; set; }
    }
}