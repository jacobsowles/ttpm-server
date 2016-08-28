using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("tasks/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var task = _taskService.GetTask(id);

            return
                task == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a task with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpPut]
        [Route("tasks")]
        public HttpResponseMessage Put(TaskDTO taskDTO)
        {
            // TODO: make sure user is allowed to modify this task
            var task = _taskService.GetTask(taskDTO.Id);

            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task with an ID of " + task.Id);
            }

            task = Mapper.Map<TaskDTO, Task>(taskDTO);

            _taskService.UpdateTask(task);
            _taskService.SaveTask();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }
    }
}