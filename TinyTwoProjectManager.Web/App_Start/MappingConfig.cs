using AutoMapper;
using TinyTwoProjectManager.Models;
using TinyTwoProjectManager.Web.ViewModels;

namespace TinyTwoProjectManager.Web.App_Start
{
    public class MappingConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Project, ProjectViewModel>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id));
                config.CreateMap<ProjectViewModel, Project>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProjectId));

                config.CreateMap<Task, TaskViewModel>().ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Id));
                config.CreateMap<TaskViewModel, Task>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskId));

                config.CreateMap<TaskList, TaskListViewModel>().ForMember(dest => dest.TaskListId, opt => opt.MapFrom(src => src.Id));
                config.CreateMap<TaskListViewModel, TaskList>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskListId));
            });
        }
    }
}