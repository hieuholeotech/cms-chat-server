using Cms.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cms.Model.Context.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("message");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Room).WithMany(x => x.Messages).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Messages).HasForeignKey(x => x.AppUserId);
        }
    }
}
