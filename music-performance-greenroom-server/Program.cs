using Microsoft.EntityFrameworkCore;
using music_performance_greenroom_server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For initial development locally
var connectionString = builder.Configuration["DevEnv:ConnectionString"];

builder.Services.AddControllers();
builder.Services.AddDbContext<GreenroomDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
