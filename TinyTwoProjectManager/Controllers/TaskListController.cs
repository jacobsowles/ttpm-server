using System.Linq;
using System.Web.Mvc;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Controllers
{
    public class TaskListController : Controller
    {
        public ProjectManagerContext db = new ProjectManagerContext();
        
        [HttpGet]
        public PartialViewResult Index(int id)
        {
            var taskList = db.TaskLists.FirstOrDefault(t => t.Id == id);

            if (taskList == null)
            {
                // TODO: throw exception
            }

            return PartialView("~/Views/TaskList/_TaskList.cshtml", taskList);
        }
    }
}