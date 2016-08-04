using System.Collections.Generic;
using System.Data.Entity;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Infrastructure
{
    public class ProjectManagerInitializer : DropCreateDatabaseIfModelChanges<ProjectManagerDbContext>
    {
        protected override void Seed(ProjectManagerDbContext context)
        {
            GetProjects().ForEach(p => context.Projects.Add(p));
            context.Commit();

            GetTaskLists().ForEach(tl => context.TaskLists.Add(tl));
            context.Commit();

            GetTasks().ForEach(t => context.Tasks.Add(t));
            context.Commit();
        }

        private static List<Project> GetProjects()
        {
            return new List<Project>
            {
                new Project { Name = "Maintenance and Repair" },
                new Project { Name = "Homestead" }
            };
        }

        private static List<TaskList> GetTaskLists()
        {
            return new List<TaskList>
            {
                new TaskList { Name = "Taurus", ProjectId = 1 },
                new TaskList { Name = "Truck", ProjectId = 1 },
                new TaskList { Name = "Tractor", ProjectId = 1 },
                new TaskList { Name = "Generator", ProjectId = 1 }
            };
        }

        private static List<Task> GetTasks()
        {
            return new List<Task>
            {
                new Task { Name = "Rotate tires", TaskListId = 1, Notes = "See http://www.greatautohelp.com/images/rotate.gif for details" },
                new Task { Name = "Check fluid levels", TaskListId = 1, Complete = true },

                new Task { Name = "Change oil", TaskListId = 3 },
                new Task { Name = "Lubricate pins", TaskListId = 3 },
                new Task { Name = "Clean engine screen", TaskListId = 3 },

                new Task { Name = "Change oil", TaskListId = 4 },
                new Task { Name = "Clean air filter", TaskListId = 4 }
            };
        }
    }
}