using api;
using api.Connection;
using api.Controllers;
using api.Services;
using NLog.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;
var coneccionSql = new Repository(config.GetConnectionString("SQL"));
builder.Services.AddSingleton(coneccionSql);

builder.Services.AddSingleton<IConnection, Connection>();
builder.Services.AddSingleton<IUsuarios, ServicioUsuarios>();
builder.Host.ConfigureLogging(( hostingContext, logging) =>
{
    logging.AddNLog();
});

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
