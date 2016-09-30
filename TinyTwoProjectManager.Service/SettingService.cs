using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ISettingService
    {
    }

    public class SettingService : ServiceBase<Setting, ISettingRepository>, ISettingService
    {
        public SettingService(ISettingRepository settingRepository, IUnitOfWork unitOfWork) : base(settingRepository, unitOfWork)
        {
        }
    }
}