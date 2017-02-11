using System.Collections.Generic;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskService
    {
        IEnumerable<Task> GetByUser(string userId, int taskGroupId = 0);

        int GetMaximumDisplayOrderForUser(string userId);
    }

    public class TaskService : ServiceBase<Task, ITaskRepository>, ITaskService
    {
        public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork) : base(taskRepository, unitOfWork)
        {
        }

        public IEnumerable<Task> GetByUser(string userId, int taskGroupId = 0)
        {
            return Repository.GetByUser(userId, taskGroupId);
        }

        public int GetMaximumDisplayOrderForUser(string userId)
        {
            return Repository.GetMaximumDisplayOrderByUser(userId);
        }
    }
}