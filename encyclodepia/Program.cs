using encyclodepia.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using encyclodepia.Data;
using encyclodepia.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<encyclodepiaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("encyclodepiaContext") ?? throw new InvalidOperationException("Connection string 'encyclodepiaContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapEncyclopediaEndpoints();

app.MapItemEndpoints();

app.Run();
