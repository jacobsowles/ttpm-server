using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;
using TinyTwoProjectManager.Web.ViewModels;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskListService _taskListService;
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService, ITaskListService taskListService)
        {
            _taskListService = taskListService;
            _taskService = taskService;
        }

        [HttpGet]
        public PartialViewResult GetTasksForTaskList(int id)
        {
            // TODO: make sure this user has permissions to interact with this task list (they could have changed the ID in Firebug or some such)
            var taskList = _taskListService.GetTaskList(id);
            var taskListViewModel = Mapper.Map<TaskList, TaskListViewModel>(taskList);

            if (taskList == null)
            {
                // TODO: Handle error
                throw new System.Exception("#nah");
            }

            var taskViewModels = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(taskList.Tasks);
            taskListViewModel.Tasks = taskViewModels;

            return PartialView("~/Views/TaskList/_TaskList.cshtml", taskListViewModel);
        }

        [HttpPost]
        public int ToggleCompletion(int id)
        {
            // TODO: make sure user is allowed to modify this task
            var task = _taskService.GetTask(id);

            if (task == null)
            {
                // TODO: throw task not found exception
                throw new System.Exception("task not found");
            }

            task.Complete = !task.Complete;
            _taskService.UpdateTask(task);
            _taskService.SaveTask();

            return task.TaskListId;
        }
    }
}