using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            this.ToTable("Project");
            this.Property(p => p.Name).IsRequired().HasMaxLength(100);

            /*this.HasRequired(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .WillCascadeOnDelete(false);*/
        }
    }
}