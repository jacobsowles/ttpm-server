using System.Collections.Generic;
using System.Data.Entity.Migrations;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TinyTwoProjectManager.Data.Infrastructure.ProjectManagerDbContext";
        }
    }
}