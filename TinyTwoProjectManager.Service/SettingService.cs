using System.Collections.Generic;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface ISettingService
    {
        void CreateSetting(Setting setting);

        void DeleteSetting(Setting setting);

        Setting GetUserSetting(int id);

        void SaveSetting();

        void UpdateSetting(Setting setting);
    }

    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(ISettingRepository settingRepository, IUnitOfWork unitOfWork)
        {
            _settingRepository = settingRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateSetting(Setting setting)
        {
            _settingRepository.Add(setting);
        }

        public void DeleteSetting(Setting setting)
        {
            _settingRepository.Delete(setting);
        }

        public Setting GetUserSetting(int id)
        {
            return _settingRepository.GetById(id);
        }

        public void SaveSetting()
        {
            _unitOfWork.Commit();
        }

        public void UpdateSetting(Setting setting)
        {
            _settingRepository.Update(setting);
        }
    }
}