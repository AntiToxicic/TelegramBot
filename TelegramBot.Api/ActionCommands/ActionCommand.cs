using MediatR;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Requests.Queries;

namespace TelegramBot.Telegram.ActionCommands;

public abstract class ActionCommand
{
    protected readonly IMediator Mediator;
    public readonly Statuses Status;
    public readonly string Command;

    protected ActionCommand(IMediator mediator, Statuses status, string command)
    {
        Mediator = mediator;
        this.Status = status;
        this.Command = command;
    }

    public abstract Task Execute(Update update);

    public async Task<bool> CheckAccess(string command, Statuses status)
    {
        if (command != TelegramCommands.START) return false;
        if (status == this.Status) return false;

        return true;
    }
} 