using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Models.BindingModels;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Tasks")]
    public class TaskController : BaseController
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var tasks = _taskService.GetByUser(User.Identity.GetUserId());
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Task>, IEnumerable<TaskDTO>>(tasks));
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var task = _taskService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(CreateTaskBindingModel bindingModel)
        {
            // TODO: create validator
            var task = Mapper.Map<CreateTaskBindingModel, Task>(bindingModel);
            task.UserId = User.Identity.GetUserId();
            task.DisplayOrder = _taskService.GetMaximumDisplayOrderForUser(task.UserId) + 1;

            _taskService.Create(task);
            _taskService.Save();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(TaskDTO taskDTO)
        {
            // TODO: make sure user is allowed to modify this task
            var task = _taskService.Get(taskDTO.Id);

            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task with an ID of " + taskDTO.Id);
            }

            task = Mapper.Map<TaskDTO, Task>(taskDTO);
            task.UserId = User.Identity.GetUserId();

            _taskService.Update(task);
            _taskService.Save();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        // TODO: change to logical delete
        [AcceptVerbs("DELETE", "OPTIONS")]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var task = _taskService.Get(id);

            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task with an ID of " + id);
            }

            _taskService.Delete(task);
            _taskService.Save();

            return
                Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpPut]
        [Route("{id:int}/ToggleComplete")]
        public HttpResponseMessage ToggleComplete(int id)
        {
            // TODO: unit test the logic here
            // TODO: make sure user is allowed to modify this task
            var task = _taskService.Get(id);

            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task with an ID of " + id);
            }

            if (!task.Complete)
            {
                if (task.TimesCompleted == 0)
                {
                    task.FirstDateCompleted = DateTime.Now;
                }

                task.LastDateCompleted = DateTime.Now;
                task.TimesCompleted++;
            }

            task.Complete = !task.Complete;

            _taskService.Update(task);
            _taskService.Save();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpPut]
        [Route("{firstTaskId:int}/SwapDisplayOrder/{secondTaskId:int}")]
        public HttpResponseMessage SwapDisplayOrder(int firstTaskId, int secondTaskId)
        {
            // TODO: unit test the logic here
            // TODO: make sure user is allowed to modify these tasks
            var firstTask = _taskService.Get(firstTaskId);
            var secondTask = _taskService.Get(secondTaskId);

            if (firstTask == null || secondTask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find one of the specified tasks.");
            }

            int firstTaskDisplayOrder = firstTask.DisplayOrder;

            firstTask.DisplayOrder = secondTask.DisplayOrder;
            secondTask.DisplayOrder = firstTaskDisplayOrder;

            _taskService.Update(firstTask);
            _taskService.Save();

            _taskService.Update(secondTask);
            _taskService.Save();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}