using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            ToTable("Task");
            Property(p => p.TaskListId).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}