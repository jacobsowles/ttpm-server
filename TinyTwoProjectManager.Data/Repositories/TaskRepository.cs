using System.Collections.Generic;
using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> GetByUser(string userId, int taskGroupId = 0);
        int GetMaximumDisplayOrderByUser(string userId);
    }

    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Task> GetByUser(string userId, int taskGroupId = 0)
        {
            return
                taskGroupId == 0
                ? GetMany(t => t.UserId == userId)
                : GetMany(t => t.UserId == userId && t.TaskGroupId == taskGroupId);
        }

        public int GetMaximumDisplayOrderByUser(string userId)
        {
            return GetByUser(userId).Max(t => t.DisplayOrder);
        }
    }
}