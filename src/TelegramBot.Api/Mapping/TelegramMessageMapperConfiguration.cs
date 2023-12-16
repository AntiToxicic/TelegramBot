using AutoMapper;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Commands;

namespace TelegramBot.Telegram.Mapping;

public class TelegramMessageMapperConfiguration : Profile
{
    public TelegramMessageMapperConfiguration()
    {
        CreateMap<Message, SavePictureCommand>()
            .ForCtorParam(nameof(SavePictureCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id))
            .ForCtorParam(nameof(SavePictureCommand.PicId), opt => opt.MapFrom(t => t.Photo!.Last().FileId))
            .ForCtorParam(nameof(SavePictureCommand.Caption), opt => opt.MapFrom(t => t.Caption))
            .ForCtorParam(nameof(SavePictureCommand.Name), opt => opt.MapFrom(t => t.Chat.Username));

        CreateMap<Message, SendRandomPictureCommand>()
            .ForCtorParam(nameof(SendRandomPictureCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id))
            .ForCtorParam(nameof(SendRandomPictureCommand.Name), opt => opt.MapFrom(t => t.Chat.Username));

        CreateMap<Message, LikePictureCommand>()
            .ForCtorParam(nameof(LikePictureCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id))
            .ForCtorParam(nameof(LikePictureCommand.Name), opt => opt.MapFrom(t => t.Chat.Username));
    }
}
