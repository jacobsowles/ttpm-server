namespace TinyTwoProjectManager.Models
{
    public class UserSettingDTO : DataTransferObject
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}