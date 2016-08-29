using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using TinyTwoProjectManager.API.Controllers;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.Controllers
{
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
            var projects = _projectService.GetProjects().ToList();

            return
                projects == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find any projects")
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, new ProjectListDTO
                {
                    Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects),
                    TaskLists = Mapper.Map<IEnumerable<TaskList>, IEnumerable<TaskListDTO>>(projects.SelectMany(p => p.TaskLists))
                });
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

        [HttpPost]
        [Route("{id:int}/taskList")]
        public HttpResponseMessage PostTaskList(int id)
        {
            var project = _projectService.GetProject(id);
            var taskList = new TaskList
            {
                Name = "New Task List",
                ProjectId = id
            };

            project.TaskLists.Add(taskList);

            _projectService.UpdateProject(project);
            _projectService.SaveProject();

            return
                project == null
                ? Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Unable to find a project with an ID of " + id)
                : Request.CreateResponse(System.Net.HttpStatusCode.OK, Mapper.Map<TaskList, TaskListDTO>(taskList));
        }
    }
}