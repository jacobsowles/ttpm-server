using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskListConfiguration : EntityTypeConfiguration<TaskList>
    {
        public TaskListConfiguration()
        {
            this.ToTable("TaskList");
            this.Property(tl => tl.Name).IsRequired().HasMaxLength(100);

            this.HasRequired(tl => tl.Project)
                .WithMany(p => p.TaskLists)
                .HasForeignKey(tl => tl.ProjectId)
                .WillCascadeOnDelete(true);
        }
    }
}