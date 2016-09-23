using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface IUserSettingRepository : IRepository<UserSetting>
    {
    }

    public class UserSettingRepository : RepositoryBase<UserSetting>, IUserSettingRepository
    {
        public UserSettingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}