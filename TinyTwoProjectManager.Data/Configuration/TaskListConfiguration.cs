using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskListConfiguration : EntityTypeConfiguration<TaskList>
    {
        public TaskListConfiguration()
        {
            ToTable("TaskList");
            Property(p => p.ProjectId).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}