using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
    }

    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}