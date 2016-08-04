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

        Task GetTask(int id);

        IEnumerable<Task> GetTasks(int taskListId);

        void SaveTask();
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

        public void CreateTask(Task Task)
        {
            _TaskRepository.Add(Task);
        }

        public Task GetTask(int id)
        {
            var Task = _TaskRepository.GetById(id);
            return Task;
        }

        public IEnumerable<Task> GetTasks(int taskListId)
        {
            var Tasks = _TaskRepository.GetAll().Where(t => t.TaskListId == taskListId);
            return Tasks;
        }

        public void SaveTask()
        {
            _unitOfWork.Commit();
        }
    }
}