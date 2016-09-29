namespace TinyTwoProjectManager.Models
{
    public class TaskDTO : DataTransferObject
    {
        public int? TaskGroupId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
        public int DisplayOrder { get; set; }
    }
}