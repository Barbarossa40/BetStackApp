using BetStackAppApi.Models;
using BetStackApp.Application;
using BetStackApp.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var secrets = builder.Configuration.GetSection("ConnectionStrings");

builder.Services.Configure<ConnectionStrings>(secrets);


// remeber to add 

builder.Services.AddAppServices();
builder.Services.AddPersistenceServices(secrets);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Open", policy =>
     {
         policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
     });
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseCors("Open");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
