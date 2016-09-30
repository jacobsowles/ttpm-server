using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
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
    [RoutePrefix("TaskGroups")]
    public class TaskGroupController : BaseController
    {
        private readonly ITaskGroupService _taskGroupService;
        private readonly ITaskGroupDisplayOrderService _taskGroupDisplayOrderService;
        private readonly ITaskService _taskService;

        public TaskGroupController(ITaskGroupService taskGroupService, ITaskGroupDisplayOrderService taskGroupDisplayOrderService, ITaskService taskService)
        {
            _taskGroupService = taskGroupService;
            _taskGroupDisplayOrderService = taskGroupDisplayOrderService;
            _taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var taskGroups = _taskGroupService.GetTaskGroupsForUser(User.Identity.GetUserId()).ToList();
            return  Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<TaskGroup>, IEnumerable<TaskGroupDTO>>(taskGroups));
        }
        
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] CreateTaskGroupBindingModel bindingModel)
        {
            // TODO: create validator
            var taskGroup = Mapper.Map<CreateTaskGroupBindingModel, TaskGroup>(bindingModel);
            taskGroup.UserId = User.Identity.GetUserId();

            // Add new task group on its own
            if (bindingModel.ParentTaskGroupId == null)
            {
                _taskGroupService.CreateTaskGroup(taskGroup);
                _taskGroupService.SaveTaskGroup();
            }

            // Add new task group to parent task group
            else
            {
                var parentTaskGroup = _taskGroupService.GetTaskGroup((int) bindingModel.ParentTaskGroupId);

                if (parentTaskGroup == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a parent task group with an ID of " + bindingModel.ParentTaskGroupId);
                }

                parentTaskGroup.TaskGroups.Add(taskGroup);
                _taskGroupService.UpdateTaskGroup(parentTaskGroup);
                _taskGroupService.SaveTaskGroup();
            }

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<TaskGroup, TaskGroupDTO>(taskGroup));
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var taskGroup = _taskGroupService.GetTaskGroup(id);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<TaskGroup, TaskGroupDTO>(taskGroup));
        }

        // TODO: change to logical delete
        [AcceptVerbs("DELETE", "OPTIONS")]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var taskGroup = _taskGroupService.GetTaskGroup(id);

            if (taskGroup == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task group with an ID of " + id);
            }

            _taskGroupService.DeleteTaskGroup(taskGroup);
            _taskGroupService.SaveTaskGroup();

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<TaskGroup, TaskGroupDTO>(taskGroup));
        }

        [HttpGet]
        [Route("{id:int}/ChildTaskGroups")]
        public HttpResponseMessage GetChildTaskGroups(int id)
        {
            var taskGroup = _taskGroupService.GetTaskGroup(id);
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<TaskGroup>, IEnumerable<TaskGroupDTO>>(taskGroup.TaskGroups));
        }

        [HttpGet]
        [Route("{id:int}/Tasks")]
        public HttpResponseMessage GetTasks(int id)
        {
            var taskGroup = _taskGroupService.GetTaskGroup(id);

            if (taskGroup == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task group with an ID of " + id);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<Task>, IEnumerable<TaskDTO>>(taskGroup.Tasks));
        }

        [HttpPost]
        [Route("{id:int}/Tasks")]
        public HttpResponseMessage CreateTask(CreateTaskInGroupBindingModel bindingModel)
        {
            // TODO: create validator
            var taskGroup = _taskGroupService.GetTaskGroup(bindingModel.TaskGroupId);

            if (taskGroup == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task group with an ID of " + bindingModel.TaskGroupId);
            }

            var task = Mapper.Map<CreateTaskInGroupBindingModel, Task>(bindingModel);
            task.UserId = User.Identity.GetUserId();
            task.DisplayOrder = _taskService.GetMaximumDisplayOrderForUser(task.UserId) + 1;

            taskGroup.Tasks.Add(task);

            _taskGroupService.UpdateTaskGroup(taskGroup);
            _taskGroupService.SaveTaskGroup();

            // Add TaskGroup display orders
            _taskGroupDisplayOrderService.AddTaskToBottomOfTaskGroups(
                taskGroup.AllAncestors().Select(tg => tg.Id),
                task.Id
            );

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Task, TaskDTO>(task));
        }

        [HttpGet]
        [Route("{id:int}/TaskDisplayOrder")]
        public HttpResponseMessage GetTaskDisplayOrder(int id)
        {
            var taskGroup = _taskGroupService.GetTaskGroup(id);

            if (taskGroup == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Unable to find a task group with an ID of " + id);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<TaskGroupDisplayOrder>, IEnumerable<TaskGroupDisplayOrderDTO>>(taskGroup.DisplayOrders));
        }
    }
}