using Telegram.Bot;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Services;
using TelegramBot.Infrastructure;
using TelegramBot.Infrastructure.DataBase;
using TelegramBot.Infrastructure.DataBase.SQLite;
using TelegramBot.Infrastructure.PictureStorage;
using TelegramBot.Telegram.Core;
using TelegramBot.Telegram.Factories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICommandProcessorFactory, CommandProcessorFactory>();
builder.Services.AddScoped<PictureReceiving>();
builder.Services.AddScoped<TelegramBotClient>(c =>
{
    var token = builder.Configuration.GetSection("TelegramBot").GetValue<string>("token");
    return new TelegramBotClient(token);
});
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IPictureService, PictureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Configuration.GetSection("TelegramBot").GetValue<string>("token");
app.Configuration.GetSection("DataBase").GetValue<string>("path");
app.Configuration.GetSection("DataBase").GetValue<string>("name");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();