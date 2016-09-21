using System.Collections.Generic;
using System.Data.Entity;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Infrastructure
{
    public class ProjectManagerInitializer : DropCreateDatabaseIfModelChanges<ProjectManagerDbContext>
    {
        protected override void Seed(ProjectManagerDbContext context)
        {
            GetTaskGroups().ForEach(tg => context.TaskGroups.Add(tg));
            context.Commit();

            GetTasks().ForEach(t => context.Tasks.Add(t));
            context.Commit();
        }

        private static List<TaskGroup> GetTaskGroups()
        {
            return new List<TaskGroup>
            {
                new TaskGroup { Name = "Maintenance and Repairs" },
                new TaskGroup { Name = "Taurus", ParentTaskGroupId = 1 },
                new TaskGroup { Name = "Truck", ParentTaskGroupId = 1 },
                new TaskGroup { Name = "Tractor", ParentTaskGroupId = 1 },
                new TaskGroup { Name = "Generator", ParentTaskGroupId = 1 },
                new TaskGroup { Name = "Homestead" }
            };
        }

        private static List<Task> GetTasks()
        {
            return new List<Task>
            {
                new Task { Name = "Rotate tires", TaskGroupId = 2, Notes = "See http://www.greatautohelp.com/images/rotate.gif for details" },
                new Task { Name = "Check fluid levels", TaskGroupId = 2, Complete = true },

                new Task { Name = "Change oil", TaskGroupId = 4 },
                new Task { Name = "Lubricate pins", TaskGroupId = 4 },
                new Task { Name = "Clean engine screen", TaskGroupId = 4 },

                new Task { Name = "Change oil", TaskGroupId = 5 },
                new Task { Name = "Clean air filter", TaskGroupId = 5 }
            };
        }
    }
}