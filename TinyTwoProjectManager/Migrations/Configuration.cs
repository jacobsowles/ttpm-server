namespace TinyTwoProjectManager.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TinyTwoProjectManager.Models.ProjectManagerContext";
        }

        protected override void Seed(ProjectManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ProjectLists.AddOrUpdate(new ProjectList { Id = 1 });
            context.Projects.AddOrUpdate(new Project { Id = 1, ProjectListId = 1, Name = "Maintenance and Repairs" });
            context.TaskLists.AddOrUpdate(new TaskList { Id = 1, ProjectId = 1, Name = "Taurus" });
            context.TaskLists.AddOrUpdate(new TaskList { Id = 2, ProjectId = 1, Name = "Truck" });
            context.TaskLists.AddOrUpdate(new TaskList { Id = 3, ProjectId = 1, Name = "Generator" });
            context.TaskLists.AddOrUpdate(new TaskList { Id = 4, ProjectId = 1, Name = "ATV (Blue)" });
            context.TaskLists.AddOrUpdate(new TaskList { Id = 5, ProjectId = 1, Name = "ATV (Green)" });
            context.TaskLists.AddOrUpdate(new TaskList { Id = 6, ProjectId = 1, Name = "Tractor" });
            context.Tasks.AddOrUpdate(new Task { Id = 1, TaskListId = 1, Name = "Change oil" });
        }
    }
}