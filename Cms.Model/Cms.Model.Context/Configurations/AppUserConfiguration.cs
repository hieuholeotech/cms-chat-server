using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cms.Model.Entities;

namespace Cms.Model.ContextConfigurations
{
    public class AppUserConfiguration:IEntityTypeConfiguration<AppUser>
    {
        public void Configure (EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("app_users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("first_name");
            builder.Property(x => x.LastName).HasMaxLength(50).HasColumnName("last_name");
            builder.Property(x => x.AccessFailedCount).HasColumnName("access_failed_count");
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.EmailConfirmed).HasColumnName("email_confirm");
            builder.Property(x => x.LockoutEnabled).HasColumnName("lockout_enabled");
            builder.Property(x => x.LockoutEnd).HasColumnName("lockout_end");
            builder.Property(x => x.NormalizedEmail).HasColumnName("normalized_email");
            builder.Property(x => x.NormalizedUserName).HasColumnName("normalized_userName");
            builder.Property(x => x.PasswordHash).HasColumnName("password_hash");
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number");
            builder.Property(x => x.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            builder.Property(x => x.SecurityStamp).HasColumnName("security_stamp");
            builder.Property(x => x.TwoFactorEnabled).HasColumnName("twoFactor_enabled");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.UserName).HasColumnName("username");
        }
    }
}
