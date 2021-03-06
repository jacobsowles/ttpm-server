﻿using AutoMapper;
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
                // Setting
                config.CreateMap<Setting, SettingDTO>();
                config.CreateMap<SettingDTO, Setting>();

                // Task
                config.CreateMap<Task, TaskDTO>();
                config.CreateMap<TaskDTO, Task>();
                config.CreateMap<CreateTaskBindingModel, Task>();
                config.CreateMap<CreateTaskInGroupBindingModel, Task>();

                // TaskGroup
                config.CreateMap<TaskGroup, TaskGroupDTO>();
                config.CreateMap<TaskGroupDTO, TaskGroup>();
                config.CreateMap<CreateTaskGroupBindingModel, TaskGroup>();

                // TaskGroupDisplayOrder
                config.CreateMap<TaskGroupDisplayOrder, TaskGroupDisplayOrderDTO>();
                config.CreateMap<TaskGroupDisplayOrderDTO, TaskGroupDisplayOrder>();

                // UserSetting
                config.CreateMap<UserSetting, UserSettingDTO>();
                config.CreateMap<UserSettingDTO, UserSetting>();
                config.CreateMap<UpdateUserSettingBindingModel, UserSetting>();
            });
        }
    }
}