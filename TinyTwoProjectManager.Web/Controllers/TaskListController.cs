using System.Web.Mvc;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ITaskListService _taskListService;

        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet]
        public PartialViewResult Index(int id)
        {
            var taskList = _taskListService.GetTaskList(id);
            return PartialView("~/Views/TaskList/_TaskList.cshtml", taskList);
        }
    }
}