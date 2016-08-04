﻿using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Services;

namespace TinyTwoProjectManager.Web.App_Start
{
    public class DependencyInjectorConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories (will grab all *Repository.cs files in the same assembly as ProjectRepository)
            builder.RegisterAssemblyTypes(typeof(ProjectRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository", System.StringComparison.CurrentCulture))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services (will grab all *Service.cs files in the same assembly as ProjectService)
            builder.RegisterAssemblyTypes(typeof(ProjectService).Assembly)
               .Where(t => t.Name.EndsWith("Service", System.StringComparison.CurrentCulture))
               .AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}