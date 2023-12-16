using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.ApplicationCore.Commands;
using TelegramBot.Telegram.Dictionaries;

namespace TelegramBot.Telegram.Controllers;

[ApiController]
[Route("[controller]")]
public class TelegramController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TelegramController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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
                case Commands.Next: await _mediator.Send(_mapper.Map<SendRandomPictureCommand>(message)); break;
                case Commands.LikePicture: await _mediator.Send(_mapper.Map<LikePictureCommand>(message)); break;
            }
        }
        else if (message?.Photo != null)
        {
            await _mediator.Send(_mapper.Map<SavePictureCommand>(message));
        }

        return Ok();
    }
}
