using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Repositories;
using Tema_dotNet.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProducatorManagementDBContext>();
builder.Services.AddScoped<ProducatorRepository>();
builder.Services.AddScoped<ProducatorService>();
builder.Services.AddScoped<ProdusRepository>();
builder.Services.AddScoped<ProdusService>();

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
