using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TinyTwoProjectManager.Data.Configuration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Infrastructure
{
    public class ProjectManagerDbContext : DbContext
    {
        public ProjectManagerDbContext() : base("ProjectManagerDbContext")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new TaskListConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
        }
    }
}