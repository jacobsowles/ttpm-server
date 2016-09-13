using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            this.ToTable("Task");
            this.Property(p => p.Name).IsRequired().HasMaxLength(100);

            this.HasRequired(t => t.TaskList)
                .WithMany(tl => tl.Tasks)
                .HasForeignKey(t => t.TaskListId)
                .WillCascadeOnDelete(true);
        }
    }
}