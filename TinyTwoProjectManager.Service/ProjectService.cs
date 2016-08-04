using System.Collections.Generic;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface IProjectService
    {
        void CreateProject(Project project);

        Project GetProject(int id);

        IEnumerable<Project> GetProjects();

        void SaveProject();
    }

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateProject(Project project)
        {
            _projectRepository.Add(project);
        }

        public Project GetProject(int id)
        {
            var project = _projectRepository.GetById(id);
            return project;
        }

        public IEnumerable<Project> GetProjects()
        {
            var projects = _projectRepository.GetAll();
            return projects;
        }

        public void SaveProject()
        {
            _unitOfWork.Commit();
        }
    }
}