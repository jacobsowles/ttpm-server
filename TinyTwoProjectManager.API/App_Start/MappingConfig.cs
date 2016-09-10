using AutoMapper;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.API
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                // Projects
                config.CreateMap<Project, ProjectDTO>();
                config.CreateMap<ProjectDTO, Project>();

                // Task Lists
                config.CreateMap<TaskList, TaskListDTO>();
                config.CreateMap<TaskListDTO, TaskList>();

                // Tasks
                config.CreateMap<Task, TaskDTO>();
                config.CreateMap<Task, TaskTableTaskDTO>();

                config.CreateMap<TaskDTO, Task>();
                config.CreateMap<TaskDTO, TaskTableTaskDTO>();

                config.CreateMap<TaskTableTaskDTO, Task>();
                config.CreateMap<TaskTableTaskDTO, TaskDTO>();
            });
        }
    }
}