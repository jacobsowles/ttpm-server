using System;
using System.Web.Mvc;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public PartialViewResult Index()
        {
            throw new NotImplementedException();
        }
    }
}