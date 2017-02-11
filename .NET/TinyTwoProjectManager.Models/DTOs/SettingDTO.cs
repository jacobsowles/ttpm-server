namespace TinyTwoProjectManager.Models
{
    public class SettingDTO : DataTransferObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
    }
}