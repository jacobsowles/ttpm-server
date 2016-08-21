using System.Web.Mvc;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;
using TinyTwoProjectManager.Web.ViewModels;

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
        public PartialViewResult GetTaskListDashboard(int id)
        {
            var taskList = _taskListService.GetTaskList(id);
            return PartialView("~/Views/TaskList/_TaskListDashboard.cshtml", new TaskListDashboardViewModel
            {
                TaskListTaskTableModule = new TaskListTaskTableModuleViewModel
                {
                    TaskList = AutoMapper.Mapper.Map<TaskList, TaskListViewModel>(taskList)
                },

                TaskListCompletionModule = new TaskListCompletionModuleViewModel(taskList)
            });
        }
    }
}