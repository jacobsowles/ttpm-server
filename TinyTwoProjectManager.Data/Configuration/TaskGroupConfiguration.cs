using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskGroupConfiguration : EntityTypeConfiguration<TaskGroup>
    {
        public TaskGroupConfiguration()
        {
            this.ToTable("TaskGroup");
            this.Property(tg => tg.Name).IsRequired().HasMaxLength(100);

            this.HasOptional(tg => tg.ParentTaskGroup)
                .WithMany(tg => tg.TaskGroups)
                .HasForeignKey(tg => tg.ParentTaskGroupId)
                .WillCascadeOnDelete(false);

            /*this.HasRequired(tg => tg.User)
                .WithMany(u => u.TaskGroups)
                .HasForeignKey(tg => tg.UserId)
                .WillCascadeOnDelete(true);*/
        }
    }
}