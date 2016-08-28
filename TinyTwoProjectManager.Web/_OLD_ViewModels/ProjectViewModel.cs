using System.Collections.Generic;
using System.Web.Mvc;

namespace TinyTwoProjectManager.Web.ViewModels
{
    public class ProjectViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }

        public string Name { get; set; }
        public IEnumerable<TaskListViewModel> TaskLists { get; set; }
    }
}