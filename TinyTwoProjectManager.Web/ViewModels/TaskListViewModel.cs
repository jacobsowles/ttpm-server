using System.Collections.Generic;
using System.Web.Mvc;

namespace TinyTwoProjectManager.Web.ViewModels
{
    public class TaskListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int TaskListId { get; set; }

        public string Name { get; set; }
        public IEnumerable<TaskViewModel> Tasks { get; set; }
        public TaskViewModel NewTask { get; set; }
    }
}