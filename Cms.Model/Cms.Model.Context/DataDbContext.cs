using Cms.Model.Context.Configurations;
using Cms.Model.ContextConfigurations;
using Cms.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cms.Model.Context
{
    public partial class DataDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Configure using Fluent API 

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());


            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("app_user_claims")
                .Property(s => s.ClaimType).HasColumnName("claim_type");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().Property(s => s.ClaimValue).HasColumnName("claim_value");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().Property(s => s.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().Property(s => s.UserId).HasColumnName("user_id");

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("app_user_roles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserRole<Guid>>().Property(s => s.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserRole<Guid>>().Property(s => s.RoleId).HasColumnName("role_id");

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("app_user_logins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserLogin<Guid>>().Property(s => s.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().Property(s => s.LoginProvider).HasColumnName("login_provider");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().Property(s => s.ProviderDisplayName).HasColumnName("provider_display_name");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().Property(s => s.ProviderKey).HasColumnName("provider_key");

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("app_role_claims");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().Property(s => s.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().Property(s => s.RoleId).HasColumnName("role_id");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().Property(s => s.ClaimValue).HasColumnName("claim_value");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().Property(s => s.ClaimType).HasColumnName("claim_type");

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("app_user_tokens").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserToken<Guid>>().Property(s => s.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserToken<Guid>>().Property(s => s.LoginProvider).HasColumnName("login_provider");
            modelBuilder.Entity<IdentityUserToken<Guid>>().Property(s => s.Name).HasColumnName("name");
            modelBuilder.Entity<IdentityUserToken<Guid>>().Property(s => s.Value).HasColumnName("value");

            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}