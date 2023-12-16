﻿using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;
using User = TelegramBot.ApplicationCore.Entities.User;

namespace TelegramBot.Telegram.Actions;

public class NewPictureAction : IExistAction
{
    private readonly IMediator _mediator;
    public event Func<Message, Task>? ExecuteDefault;
    public event Func<Message, Task>? ExecuteNotRegisteredDefault;

    public NewPictureAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(Message message)
    {
        User? user = await _mediator.Send(new GetUserCommand(message.Chat.Id));

        if (user is null)
        {
            await ExecuteNotRegisteredDefault?.Invoke(message)!;
            return;
        }
        
        Statuses status = user!.Status;
        
        if (status is not Statuses.AWAITPICTURE)
        {
            await ExecuteDefault?.Invoke(message)!;
            return;
        }
        
        await _mediator.Send(new SavePictureCommand(
            PicId: message.Photo.Last().FileId,
            Caption: message.Caption,
            UserId: message.Chat.Id));
        await _mediator.Send(new SendMessageCommand(
            Message: BotTextAnswers.ACCEPTPICTURE,
            ChatId: message.Chat.Id,
            Status: Statuses.WATCH));
    }
}