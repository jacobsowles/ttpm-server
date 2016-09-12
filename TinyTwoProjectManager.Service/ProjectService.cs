using System;
using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface IProjectService
    {
        void CreateProject(Project project);

        void DeleteProject(Project project);

        Project GetProject(int id);

        IQueryable<Project> GetProjects();

        void SaveProject();

        void UpdateProject(Project project);
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

        public void DeleteProject(Project project)
        {
            _projectRepository.Delete(project);
        }

        public Project GetProject(int id)
        {
            return _projectRepository.GetById(id);
        }

        public IQueryable<Project> GetProjects()
        {
            return _projectRepository.GetAll();
        }

        public void SaveProject()
        {
            _unitOfWork.Commit();
        }

        public void UpdateProject(Project project)
        {
            _projectRepository.Update(project);
        }
    }
}