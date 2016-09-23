using System.Collections.Generic;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public interface IUserSettingService
    {
        void CreateUserSetting(UserSetting userSetting);

        void DeleteUserSetting(UserSetting userSetting);

        UserSetting GetUserSetting(int id);

        IEnumerable<UserSetting> GetSettingsForUser(string userId);

        void SaveUserSetting();

        void UpdateUserSetting(UserSetting userSetting);
    }

    public class UserSettingService : IUserSettingService
    {
        private readonly IUserSettingRepository _userSettingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserSettingService(IUserSettingRepository userSettingRepository, IUnitOfWork unitOfWork)
        {
            _userSettingRepository = userSettingRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateUserSetting(UserSetting userSetting)
        {
            _userSettingRepository.Add(userSetting);
        }

        public void DeleteUserSetting(UserSetting userSetting)
        {
            _userSettingRepository.Delete(userSetting);
        }

        public UserSetting GetUserSetting(int id)
        {
            return _userSettingRepository.GetById(id);
        }

        public IEnumerable<UserSetting> GetSettingsForUser(string userId)
        {
            return _userSettingRepository.GetMany(t => t.UserId == userId);
        }

        public void SaveUserSetting()
        {
            _unitOfWork.Commit();
        }

        public void UpdateUserSetting(UserSetting userSetting)
        {
            _userSettingRepository.Update(userSetting);
        }
    }
}