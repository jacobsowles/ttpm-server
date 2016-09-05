using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface IProductivityStatusRepository : IRepository<ProductivityStatus>
    {
    }

    public class ProductivityStatusRepository : RepositoryBase<ProductivityStatus>, IProductivityStatusRepository
    {
        public ProductivityStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}