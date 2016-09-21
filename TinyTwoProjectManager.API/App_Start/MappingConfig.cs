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
                // TaskGroups
                config.CreateMap<TaskGroup, TaskGroupDTO>();
                config.CreateMap<TaskGroupDTO, TaskGroup>();
                config.CreateMap<CreateTaskGroupBindingModel, TaskGroup>();

                // Tasks
                config.CreateMap<Task, TaskDTO>();
                config.CreateMap<TaskDTO, Task>();
                config.CreateMap<CreateTaskBindingModel, Task>();
                config.CreateMap<CreateTaskInGroupBindingModel, Task>();
            });
        }
    }
}