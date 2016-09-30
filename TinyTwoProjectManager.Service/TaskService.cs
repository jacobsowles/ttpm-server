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

        int GetMaximumDisplayOrderForUser(string userId);
    }

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(ITaskRepository TaskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = TaskRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateTask(Task task)
        {
            _taskRepository.Add(task);
        }

        public void DeleteTask(Task task)
        {
            _taskRepository.Delete(task);
        }

        public Task GetTask(int id)
        {
            var Task = _taskRepository.GetById(id);
            return Task;
        }

        public IEnumerable<Task> GetTasksForUser(string userId, int taskGroupId = 0)
        {
            var Tasks =  _taskRepository.GetMany(t => t.UserId == userId);

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
            _taskRepository.Update(task);
        }

        public int GetMaximumDisplayOrderForUser(string userId)
        {
            return GetTasksForUser(userId).Max(t => t.DisplayOrder);
        }
    }
}