using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface ITaskGroupDisplayOrderRepository : IRepository<TaskGroupDisplayOrder>
    {
    }

    public class TaskGroupDisplayOrderRepository : RepositoryBase<TaskGroupDisplayOrder>, ITaskGroupDisplayOrderRepository
    {
        public TaskGroupDisplayOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}