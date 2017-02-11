using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class UserSettingConfiguration : EntityTypeConfiguration<UserSetting>
    {
        public UserSettingConfiguration()
        {
            this.ToTable("UserSetting");
            this.Property(us => us.Value).IsRequired().HasMaxLength(100);

            this.HasRequired(us => us.User)
                .WithMany(u => u.UserSettings)
                .HasForeignKey(us => us.UserId)
                .WillCascadeOnDelete(true);

            this.HasRequired(us => us.Setting)
                .WithMany(s => s.UserSettings)
                .HasForeignKey(us => us.SettingId)
                .WillCascadeOnDelete(false);
        }
    }
}