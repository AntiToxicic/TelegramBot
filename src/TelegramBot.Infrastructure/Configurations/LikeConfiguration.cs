using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(c => new { c.UserId, c.PictureInfoId});

        builder
            .HasOne(c => c.User)
            .WithMany();

        builder
            .HasOne(c => c.Picture)
            .WithMany();

        builder.HasIndex(c => new {c.PictureInfoId, c.UserId}).IsUnique();
    }
}
