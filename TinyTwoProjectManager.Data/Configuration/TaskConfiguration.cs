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

            this.HasOptional(t => t.TaskGroup)
                .WithMany(tl => tl.Tasks)
                .HasForeignKey(t => t.TaskGroupId)
                .WillCascadeOnDelete(true);

            this.HasRequired(tg => tg.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(tg => tg.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}