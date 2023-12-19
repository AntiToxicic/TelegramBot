using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBot.ApplicationCore.Entities;

namespace TelegramBot.Infrastructure.Configurations;

public class PictureInfoConfiguration : IEntityTypeConfiguration<PictureInfo>
{
    public void Configure(EntityTypeBuilder<PictureInfo> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
