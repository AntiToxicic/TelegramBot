﻿using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Telegram.Interfaces;

namespace TelegramBot.Telegram.Actions;

public class LikeAction : IAction
{
    private readonly IMediator _mediator;
    public event Action<Message>? ExecuteDefault;

    public LikeAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(Message message)
    {
        Statuses status = (await _mediator.Send(new GetUserCommand(message.Chat.Id))).Status;

        if (status is not Statuses.WATCH)
        {
            ExecuteDefault?.Invoke(message);
            return;
        }
        
        await _mediator.Send(new SendRandomPictureCommand(
            ChatId: message.Chat.Id));
        await _mediator.Send(new IncreasePictureRatingCommand(
            UserId: message.Chat.Id));
    }
}