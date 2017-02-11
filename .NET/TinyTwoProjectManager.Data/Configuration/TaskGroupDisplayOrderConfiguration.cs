using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskGroupDisplayOrderConfiguration : EntityTypeConfiguration<TaskGroupDisplayOrder>
    {
        public TaskGroupDisplayOrderConfiguration()
        {
            this.ToTable("TaskGroupDisplayOrder");
            this.Property(tgdo => tgdo.DisplayOrder).IsRequired();

            this.HasRequired(tgdo => tgdo.TaskGroup)
                .WithMany(tg => tg.DisplayOrders)
                .HasForeignKey(tgdo => tgdo.TaskGroupId)
                .WillCascadeOnDelete(false);    // can't cascade because deleting a task group already cascades to delete any child tasks

            this.HasRequired(tgdo => tgdo.Task)
                .WithMany(t => t.DisplayOrders)
                .HasForeignKey(tgdo => tgdo.TaskId)
                .WillCascadeOnDelete(true);
        }
    }
}