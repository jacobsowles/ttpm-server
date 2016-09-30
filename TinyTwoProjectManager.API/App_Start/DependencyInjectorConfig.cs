using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.API
{
    public class DependencyInjectorConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(DependencyInjectorConfig).GetTypeInfo().Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories (will grab all *Repository.cs files in the same assembly as ProjectRepository)
            builder.RegisterAssemblyTypes(typeof(TaskGroupRepository).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Repository", System.StringComparison.CurrentCulture))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services (will grab all *Service.cs files in the same assembly as ProjectService)
            builder.RegisterAssemblyTypes(typeof(TaskGroupService).GetTypeInfo().Assembly)
               .Where(t => t.Name.EndsWith("Service", System.StringComparison.CurrentCulture))
               .InstancePerRequest();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}