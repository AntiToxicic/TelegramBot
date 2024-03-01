using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Features.Commands;
using TelegramBot.Telegram.Dictionaries;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private readonly IMediator _mediator;
        private readonly IMapper _mapper;
    private ITelegramBotClient _tbot;

    public TelegramController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tbot.SendTextMessageAsync(1, "3");
    }

    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook(Update update)
    {
        var message = update.Message;
        var command = message?.Text;

        if (!string.IsNullOrEmpty(command))
        {
            switch (command)
            {
                case Command.NextPicture: await _mediator.Send(_mapper.Map<SendRandomPictureCommand>(message)); break;
                case Command.LikePicture: await _mediator.Send(_mapper.Map<LikePictureCommand>(message)); break;
            }
        }
        else if (message?.Photo is not null)
        {
            await _mediator.Send(_mapper.Map<SavePictureCommand>(message));
        }

        return Ok();
    }
}
