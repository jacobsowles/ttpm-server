using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            ToTable("Project");
            Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}