using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
    }

    public class TaskListRepository : RepositoryBase<TaskList>, ITaskListRepository
    {
        public TaskListRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}