using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("tasks")]
    public class TaskController : BaseController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var tasks = _taskService.GetTasks();
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Task>, IEnumerable<TaskDTO>>(tasks));
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var task = _taskService.GetTask(id);

            return
                task == null
                ? Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task with an ID of " + id)
                : Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpPut]
        [Route("")]
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

        [HttpGet]
        [Route("tasktable")]
        public HttpResponseMessage GetTaskTable()
        {
            var tasks = _taskService.GetTasks();

            return
                Request.CreateResponse(HttpStatusCode.OK, new TaskTableDTO
                {
                    Tasks = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskTableTaskDTO>>(tasks)
                });
        }
    }
}