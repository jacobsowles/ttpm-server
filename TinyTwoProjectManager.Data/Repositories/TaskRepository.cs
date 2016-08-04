using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
    }

    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}