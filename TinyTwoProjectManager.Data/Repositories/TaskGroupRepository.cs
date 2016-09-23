using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface ITaskGroupRepository : IRepository<TaskGroup>
    {
    }

    public class TaskGroupRepository : RepositoryBase<TaskGroup>, ITaskGroupRepository
    {
        public TaskGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}