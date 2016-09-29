using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            this.ToTable("Task");
            this.Property(t => t.Name).IsRequired().HasMaxLength(100);
            this.Property(t => t.DisplayOrder).IsRequired();

            this.HasOptional(t => t.TaskGroup)
                .WithMany(tg => tg.Tasks)
                .HasForeignKey(t => t.TaskGroupId)
                .WillCascadeOnDelete(true);

            this.HasRequired(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}