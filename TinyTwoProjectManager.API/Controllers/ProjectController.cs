using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Models.BindingModels;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("projects")]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            // TODO: This should really be in a ProjectListController, since we're not actually retrieving Projects from this route.
            var projects = _projectService.GetProjects().ToList();
            var taskLists = projects.SelectMany(p => p.TaskLists);

            return
                projects == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find any projects")
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects));
        }

        // TODO: replace DTO with binding model and create auto mapping
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] ProjectDTO projectDto)
        {
            var project = Mapper.Map<ProjectDTO, Project>(projectDto);

            _projectService.CreateProject(project);
            _projectService.SaveProject();

            return
                Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<Project, ProjectDTO>(project));
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var project = _projectService.GetProject(id);

            return
                project == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a project with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<Project, ProjectDTO>(project));
        }

        // TODO: change to logical delete
        [AcceptVerbs("DELETE", "OPTIONS")]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var project = _projectService.GetProject(id);

            if (project == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a project with an ID of " + id);
            }

            _projectService.DeleteProject(project);
            _projectService.SaveProject();

            return
                Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<Project, ProjectDTO>(project));
        }

        [HttpGet]
        [Route("{id:int}/taskLists")]
        public HttpResponseMessage GetTaskLists(int id)
        {
            var project = _projectService.GetProject(id);

            return
                project == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a project with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<IEnumerable<TaskList>, IEnumerable<TaskListDTO>>(project.TaskLists));
        }

        // TODO: create auto mapping for binding model
        [HttpPost]
        [Route("{projectId:int}/taskLists")]
        public HttpResponseMessage PostTaskList(int projectId, [FromBody] CreateTaskListBindingModel bindingModel)
        {
            var project = _projectService.GetProject(projectId);
            var taskList = new TaskList
            {
                Name = bindingModel.Name,
                ProjectId = projectId
            };

            project.TaskLists.Add(taskList);

            _projectService.UpdateProject(project);
            _projectService.SaveProject();

            return
                project == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a project with an ID of " + projectId)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<TaskList, TaskListDTO>(taskList));
        }
    }
}