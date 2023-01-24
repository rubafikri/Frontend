using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Data;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Mapper;
using RecipeWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddMapping().AddDataLayer(configuration);

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

app.Run();
