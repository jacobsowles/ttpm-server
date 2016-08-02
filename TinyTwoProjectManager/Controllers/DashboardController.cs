using System.Web.Mvc;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.ViewModels;

namespace TinyTwoProjectManager.Controllers
{
    public class DashboardController : Controller
    {
        public ProjectManagerContext db = new ProjectManagerContext();
        
        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                ProjectList = db.ProjectLists.Find(1)
            };

            return View(viewModel);
        }
    }
}