using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskGroupService
    {
        void CreateTaskGroup(TaskGroup taskGroup);

        void DeleteTaskGroup(TaskGroup taskGroup);

        TaskGroup GetTaskGroup(int id);

        IQueryable<TaskGroup> GetTaskGroups();

        void SaveTaskGroup();

        void UpdateTaskGroup(TaskGroup taskGroup);
    }

    public class TaskGroupService : ITaskGroupService
    {
        private readonly ITaskGroupRepository _taskGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskGroupService(ITaskGroupRepository taskGroupRepository, IUnitOfWork unitOfWork)
        {
            _taskGroupRepository = taskGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateTaskGroup(TaskGroup taskGroup)
        {
            _taskGroupRepository.Add(taskGroup);
        }

        public void DeleteTaskGroup(TaskGroup taskGroup)
        {
            _taskGroupRepository.Delete(taskGroup);
        }

        public TaskGroup GetTaskGroup(int id)
        {
            return _taskGroupRepository.GetById(id);
        }

        public IQueryable<TaskGroup> GetTaskGroups()
        {
            return _taskGroupRepository.GetAll();
        }

        public void SaveTaskGroup()
        {
            _unitOfWork.Commit();
        }

        public void UpdateTaskGroup(TaskGroup taskGroup)
        {
            _taskGroupRepository.Update(taskGroup);
        }
    }
}