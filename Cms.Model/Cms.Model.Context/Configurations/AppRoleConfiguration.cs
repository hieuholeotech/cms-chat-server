using Cms.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Model.ContextConfigurations
{
    public class AppRoleConfiguration:IEntityTypeConfiguration<AppRole>
    {
        public void Configure (EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("app_roles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            builder.Property(x => x.NormalizedName).HasColumnName("normalized_name");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Id).HasColumnName("id");
        }
    }
}
