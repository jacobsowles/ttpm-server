using System.Collections.Generic;
using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskService
    {
        void CreateTask(Task Task);

        void DeleteTask(Task Task);

        Task GetTask(int id);

        IEnumerable<Task> GetTasksForUser(string userId, int taskGroupId = 0);

        void SaveTask();

        void UpdateTask(Task task);
    }

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _TaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(ITaskRepository TaskRepository, IUnitOfWork unitOfWork)
        {
            _TaskRepository = TaskRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateTask(Task task)
        {
            _TaskRepository.Add(task);
        }

        public void DeleteTask(Task task)
        {
            _TaskRepository.Delete(task);
        }

        public Task GetTask(int id)
        {
            var Task = _TaskRepository.GetById(id);
            return Task;
        }

        public IEnumerable<Task> GetTasksForUser(string userId, int taskGroupId = 0)
        {
            var Tasks =
                _TaskRepository
                    .GetMany(t => t.UserId == userId)
                    .OrderBy(t => t.DisplayOrder);

            return
                taskGroupId == 0
                ? Tasks
                : Tasks.Where(t => t.TaskGroupId == taskGroupId);
        }

        public void SaveTask()
        {
            _unitOfWork.Commit();
        }

        public void UpdateTask(Task task)
        {
            _TaskRepository.Update(task);
        }
    }
}