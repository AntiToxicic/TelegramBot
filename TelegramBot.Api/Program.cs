using System.Net.NetworkInformation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBot.ApplicationCore;
using TelegramBot.ApplicationCore.Entities;
using TelegramBot.ApplicationCore.Handlers.Commands;
using TelegramBot.ApplicationCore.Handlers.Queries;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Message.Handlers.Commands;
using TelegramBot.ApplicationCore.Message.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Commands;
using TelegramBot.ApplicationCore.Requests.Queries;
using TelegramBot.Infrastructure;
using TelegramBot.Telegram;
using TelegramBot.Telegram.Common;
using TelegramBot.Telegram.Factories;
using TelegramBot.Telegram.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));

builder.Services.AddScoped<ITelegramBotClient>(c =>
{
    var token = builder.Configuration.GetSection("TelegramBot").GetValue<string>("token");
    return new TelegramBotClient(token);
});

builder.Services.AddScoped<PostgresContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IPictureDownloader, PictureDownloader>();
builder.Services.AddScoped<IPictureSender, PictureSender>();
builder.Services.AddScoped<IUserInfoReceiving, UserInfoReceiving>();
builder.Services.AddScoped<IKeyboardMarkupConstructor, KeyboardMarkupConstructor>();
builder.Services.AddScoped<IMessageSender, MessageSender>();
builder.Services.AddScoped<IActionFactory, ActionFactory>();

builder.Services.AddScoped<IRequestHandler<SavePictureCommand>, SavePictureCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SendFirstPictureCommand>, SendFirstPictureCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SendRandomPictureCommand>, SendRandomPictureCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SaveUserInfoCommand>, SaveUserInfoCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SendMessageCommand>, SendMessageCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddLikeCommand>, AddLikeCommandHandler>();
builder.Services.AddScoped<IRequestHandler<SendUserStatisticCommand>, SendUserStatisticCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetUserCommand, User?>, GetUserCommandHandler>();
builder.Services.AddScoped<TelegramCommands>();
builder.Services.AddScoped<BotTextAnswers>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();