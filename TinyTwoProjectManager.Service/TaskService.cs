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

        IEnumerable<Task> GetTasks(int taskListId = 0);

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

        public IEnumerable<Task> GetTasks(int taskListId = 0)
        {
            var Tasks = _TaskRepository.GetAll();

            return
                taskListId == 0
                ? Tasks
                : Tasks.Where(t => t.TaskListId == taskListId);
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