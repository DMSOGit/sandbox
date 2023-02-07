using SwagTest;
using Serilog;
using System.Text;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WeatherClient>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddLogging(builder => builder.AddSerilog(dispose: true));

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"{Environment.CurrentDirectory}\\..\\Log\\.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
                .CreateLogger();

//serilog
//trouver comment le faire utiliser par le framework
//logger dans un .txt a chaque fois que quelqu'un fait un call
//le rendre "rolling" pour just avoir 10 fichiers de log en rotation
//1 file par journée, donc le nom de la file sera la date
//call de base "api a ete appeller"
//logger aussi ce que le framework ecrit (something about startup file)

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
