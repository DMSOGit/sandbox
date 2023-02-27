using SwagTest;
using Serilog;
using SwagTest.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WeatherClient>();
builder.Services.AddSingleton<HttpClient>();

//add logger to framework
builder.Services.AddLogging(builder => builder.AddSerilog(dispose: true));

//setup of logger
//This setup will log everything daily in a file named after the current date in the Log directory of the project
//It will keep the latest 10 files in the directory
var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

//serilog
//logger dans le projet sans utiliser Environement (supposé être automatique)
//configure logger with logsettings.json file
//minimumlevel warning, checker les different lvl

//ne pas faire Log.Information("Calling Get");, trouver comment insérer ça dans le framework
//pour caller les controlleurs sont appelé (ce qui veut apparement dire les calls http)
//autrement dit: quand un call a mon api est fait, on doit le logger
//avec une classe IMiddleware


//ExceptionFilter : OnException
//a checker pour voir

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<SerilogMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();