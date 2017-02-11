using System.Linq;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ITaskGroupService
    {
        IQueryable<TaskGroup> GetByUser(string userId);
    }

    public class TaskGroupService : ServiceBase<TaskGroup, ITaskGroupRepository>, ITaskGroupService
    {
        public TaskGroupService(ITaskGroupRepository taskGroupRepository, IUnitOfWork unitOfWork) : base(taskGroupRepository, unitOfWork)
        {
        }

        // TODO: move this logic to the repository
        public IQueryable<TaskGroup> GetByUser(string userId)
        {
            return Repository.GetMany(tg => tg.UserId == userId);
        }
    }
}