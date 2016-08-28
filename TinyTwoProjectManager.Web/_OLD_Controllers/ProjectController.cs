using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Services;
using TinyTwoProjectManager.Web.Validators;
using TinyTwoProjectManager.Web.ViewModels;

namespace TinyTwoProjectManager.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public PartialViewResult Create(ProjectViewModel projectViewModel)
        {
            var validationResult = new ProjectViewModelValidator().Validate(projectViewModel);

            if (validationResult.IsValid)
            {
                var project = Mapper.Map<ProjectViewModel, Project>(projectViewModel);
                _projectService.CreateProject(project);

                var projectList = _projectService.GetProjects();
                var projectListViewModel = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projectList);

                return PartialView("~/Views/Project/_ProjectList.cshtml", projectListViewModel);
            }

            // TODO: Return error result
            throw new NotImplementedException();
        }
    }
}