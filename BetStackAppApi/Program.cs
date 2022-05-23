using BetStackAppApi.Models;
using BetStackApp.Application;
using BetStackApp.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;


builder.Services.AddAppServices();
builder.Services.AddPersistenceServices(Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var secrets = builder.Configuration.GetSection("WebApiOptions");

builder.Services.Configure<WebApiOptions>(secrets);

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
