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
                config.CreateMap<Project, ProjectDTO>();
                config.CreateMap<ProjectDTO, Project>();

                config.CreateMap<TaskList, TaskListDTO>();
                config.CreateMap<TaskListDTO, TaskList>();

                config.CreateMap<Task, TaskDTO>();
                config.CreateMap<TaskDTO, Task>();
            });
        }
    }
}