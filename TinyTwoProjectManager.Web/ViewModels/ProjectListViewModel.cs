using System.Collections.Generic;

namespace TinyTwoProjectManager.Web.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public ProjectViewModel NewProject { get; set; }
    }
}