using System;

namespace TinyTwoProjectManager.Models.BindingModels
{
    public class UpdateTaskBindingModel
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PlannedDate { get; set; }
        public string DueDate { get; set; }
    }
}