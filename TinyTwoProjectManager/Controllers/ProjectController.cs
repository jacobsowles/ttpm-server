using System.Linq;
using System.Web.Mvc;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        public ProjectManagerContext db = new ProjectManagerContext();
        
        [HttpPost]
        public PartialViewResult Create(Project newProject)
        {
            db.Projects.Add(newProject);
            db.SaveChanges();

            var projectList = db.ProjectLists.SingleOrDefault(pl => pl.Id == 1);

            return PartialView("~/Views/Project/_ProjectList.cshtml", projectList);
        }
    }
}