using System.Data.Entity.ModelConfiguration;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Data.Configuration
{
    public class ProductivityStatusConfiguration : EntityTypeConfiguration<ProductivityStatus>
    {
        public ProductivityStatusConfiguration()
        {
            this.ToTable("ProductivityStatus");
            this.Property(ps => ps.Name).IsRequired().HasMaxLength(100);
            this.Property(ps => ps.Rank).IsRequired();
        }
    }
}