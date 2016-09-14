using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("tasklists")]
    public class TaskListController : BaseController
    {
        private readonly ITaskListService _taskListService;

        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var taskLists = _taskListService.GetTaskLists().ToList();

            return
                taskLists == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find any task lists")
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<IEnumerable<TaskList>, IEnumerable<TaskListDTO>>(taskLists));
        }

        [AcceptVerbs("DELETE", "OPTIONS")]
        [Route("{id:int}")]
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
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var taskList = _taskListService.GetTaskList(id);

            return
                taskList == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a task list with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<TaskList, TaskListDTO>(taskList));
        }

        [HttpGet]
        [Route("{id:int}/tasks")]
        public HttpResponseMessage GetTasks(int id)
        {
            var taskList = _taskListService.GetTaskList(id);

            return
                taskList == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a task with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<IEnumerable<Task>, IEnumerable<TaskDTO>>(taskList.Tasks));
        }

        // TODO: create auto mapping for binding model
        [HttpPost]
        [Route("{taskListId:int}/tasks")]
        public HttpResponseMessage CreateTaskTaskBindingModel(TaskBindingModel bindingModel)
        {
            // TODO: create validator
            var taskList = _taskListService.GetTaskList(bindingModel.TaskListId);

            if (taskList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task list with an ID of " + bindingModel.TaskListId);
            }

            var task = Mapper.Map<TaskBindingModel, Task>(bindingModel);

            taskList.Tasks.Add(task);

            _taskListService.UpdateTaskList(taskList);
            _taskListService.SaveTaskList();

            return
                Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }
    }
}