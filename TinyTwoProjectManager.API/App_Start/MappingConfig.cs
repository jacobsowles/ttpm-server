using AutoMapper;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Models.BindingModels;

namespace TinyTwoProjectManager.API
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                // TaskGroup
                config.CreateMap<TaskGroup, TaskGroupDTO>();
                config.CreateMap<TaskGroupDTO, TaskGroup>();
                config.CreateMap<CreateTaskGroupBindingModel, TaskGroup>();

                // Task
                config.CreateMap<Task, TaskDTO>();
                config.CreateMap<TaskDTO, Task>();
                config.CreateMap<CreateTaskBindingModel, Task>();
                config.CreateMap<CreateTaskInGroupBindingModel, Task>();

                // UserSetting
                config.CreateMap<UserSetting, UserSettingDTO>();
                config.CreateMap<UserSettingDTO, UserSetting>();
                config.CreateMap<UpdateUserSettingBindingModel, UserSetting>();
            });
        }
    }
}