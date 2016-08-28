using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;
using TinyTwoProjectManager.Web.ViewModels;

namespace TinyTwoProjectManager.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IProjectService _projectService;

        public DashboardController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            var projects = _projectService.GetProjects();
            var projectViewModels = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

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