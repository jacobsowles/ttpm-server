using AutoMapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class TaskListController : BaseController
    {
        private readonly ITaskListService _taskListService;

        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpDelete]
        [Route("tasklists/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var taskList = _taskListService.GetTaskList(id);

            if (taskList == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a task list with an ID of " + id);
            }

            _taskListService.DeleteTaskList(taskList);
            _taskListService.SaveTaskList();

            return
                Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<TaskList, TaskListDTO>(taskList));
        }

        [HttpGet]
        [Route("tasklists/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var taskList = _taskListService.GetTaskList(id);

            return
                taskList == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a task list with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<TaskList, TaskListDTO>(taskList));
        }

        [HttpGet]
        [Route("tasklists/{id:int}/tasks")]
        public HttpResponseMessage GetTasks(int id)
        {
            var taskList = _taskListService.GetTaskList(id);

            return
                taskList == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a task with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<IEnumerable<Task>, IEnumerable<TaskDTO>>(taskList.Tasks));
        }
    }
}