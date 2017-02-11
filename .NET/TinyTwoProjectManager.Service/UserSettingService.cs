using System.Collections.Generic;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface IUserSettingService
    {
        IEnumerable<UserSetting> GetByUser(string userId);
    }

    public class UserSettingService : ServiceBase<UserSetting, IUserSettingRepository>, IUserSettingService
    {
        public UserSettingService(IUserSettingRepository userSettingRepository, IUnitOfWork unitOfWork) : base(userSettingRepository, unitOfWork)
        {
        }

        // TODO: move this logic to the repository
        public IEnumerable<UserSetting> GetByUser(string userId)
        {
            return Repository.GetMany(t => t.UserId == userId);
        }
    }
}