using System.Data.Entity;

namespace TinyTwoProjectManager.Models
{
    public class ProjectManagerContext : DbContext
    {
        public DbSet<ProjectList> ProjectLists { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}