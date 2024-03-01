using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.Configurations;

public class PictureInfoConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
