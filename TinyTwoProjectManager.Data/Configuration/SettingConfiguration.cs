using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class SettingConfiguration : EntityTypeConfiguration<Setting>
    {
        public SettingConfiguration()
        {
            this.ToTable("Setting");
            this.Property(s => s.Name).IsRequired().HasMaxLength(100);
            this.Property(s => s.Description).HasMaxLength(500);
        }
    }
}