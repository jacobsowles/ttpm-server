using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;
using TinyTwoProjectManager.Web.ViewModels;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ITaskListService _taskListService;
        private readonly ITaskService _taskService;

        public DashboardController(IProjectService projectService, ITaskListService taskListService, ITaskService taskService)
        {
            _projectService = projectService;
            _taskListService = taskListService;
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            var projects = _projectService.GetProjects();
            var projectViewModels = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            foreach (var projectViewModel in projectViewModels)
            {
                var taskLists = _taskListService.GetTaskLists(projectViewModel.ProjectId);
                var taskListViewModels = Mapper.Map<IEnumerable<TaskList>, IEnumerable<TaskListViewModel>>(taskLists);

                foreach (var taskListViewModel in taskListViewModels)
                {
                    var tasks = _taskService.GetTasks(taskListViewModel.TaskListId);
                    taskListViewModel.Tasks = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(tasks);
                }

                projectViewModel.TaskLists = taskListViewModels;
            }

            var dashboardViewModel = new DashboardViewModel
            {
                ProjectList = new ProjectListViewModel
                {
                    Projects = projectViewModels,
                    NewProject = new ProjectViewModel()
                }
            };

            return View(dashboardViewModel);
        }
    }
}