using Telegram.Bot;
using TelegramBot.ApplicationCore.Interfaces;
using TelegramBot.ApplicationCore.Services;
using TelegramBot.Infrastructure;
using TelegramBot.Infrastructure.DataBase;
using TelegramBot.Infrastructure.PictureStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPictureReceiveFactory, PictureReceiveFactory>();
builder.Services.AddScoped<PictureReceive>();
builder.Services.AddScoped<TelegramBotClient>(c =>
{
    var token = builder.Configuration.GetSection("TelegramBot").GetValue<string>("token");
    return new TelegramBotClient(token);
});
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IPictureTransfer, PictureTransfer>();
builder.Services.AddScoped<IPictureService, PictureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.Configuration.GetSection("TelegramBot").GetValue<string>("token");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();