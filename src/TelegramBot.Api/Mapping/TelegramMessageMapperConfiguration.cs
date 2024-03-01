using AutoMapper;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Features.Commands;
using TelegramBot.ApplicationCore.Features.Notifications.Requests;
using TelegramBot.ApplicationCore.Features.Queries.Requests;

namespace TelegramBot.Telegram.Mapping;

public class TelegramMessageMapperConfiguration : Profile
{
    public TelegramMessageMapperConfiguration()
    {
        CreateMap<Message, SavePictureCommand>()
            .ForCtorParam(nameof(SavePictureCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id))
            .ForCtorParam(nameof(SavePictureCommand.PicId), opt => opt.MapFrom(t => t.Photo!.Last().FileId))
            .ForCtorParam(nameof(SavePictureCommand.Caption), opt => opt.MapFrom(t => t.Caption));

        CreateMap<Message, SendRandomPictureCommand>()
            .ForCtorParam(nameof(SendRandomPictureCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id));

        CreateMap<Message, LikePictureCommand>()
            .ForCtorParam(nameof(LikePictureCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id));
        
        CreateMap<Message, BackToWatchCommand>()
            .ForCtorParam(nameof(BackToWatchCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id));        
        
        CreateMap<Message, GetStartCommand>()
            .ForCtorParam(nameof(GetStartCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id));
        
        CreateMap<Message, StartCommand>()
            .ForCtorParam(nameof(StartCommand.ChatId), opt => opt.MapFrom(t => t.Chat.Id))
            .ForCtorParam(nameof(StartCommand.UserName), opt => opt.MapFrom(t => t.Chat.Username));
        
        CreateMap<Message, BadPhotoNotification>()
            .ForCtorParam(nameof(BadPhotoNotification.ChatId), opt => opt.MapFrom(t => t.Chat.Id));
        
        CreateMap<Message, WrongCommandNotification>()
            .ForCtorParam(nameof(WrongCommandNotification.ChatId), opt => opt.MapFrom(t => t.Chat.Id));
        
        CreateMap<Message, GetRulesQuery>()
            .ForCtorParam(nameof(GetRulesQuery.ChatId), opt => opt.MapFrom(t => t.Chat.Id));
        
        CreateMap<Message, GetUserStatisticQuery>()
            .ForCtorParam(nameof(GetUserStatisticQuery.ChatId), opt => opt.MapFrom(t => t.Chat.Id));
    }
}
