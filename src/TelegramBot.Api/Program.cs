using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBot.ApplicationCore;
using TelegramBot.Infrastructure;
using TelegramBot.Infrastructure.Options;
using TelegramBot.Telegram.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostgresContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresContext")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationCoreMarker)));

builder.Services.AddHttpClient<ITelegramBotClient, TelegramBotClient>(c =>
{
    var telegramOptions = builder.Configuration.GetSection(nameof(TelegramOptions)).Get<TelegramOptions>();
    return new TelegramBotClient(telegramOptions!.Token, c);
});

builder.Services.Configure<PictureStorageOptions>(builder.Configuration.GetSection(nameof(PictureStorageOptions)));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<PostgresContext>();
await context.Database.MigrateAsync();

await app.RunAsync();
