using BookStore.API.Data;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Data;
using RecipeWebApi.Mapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
builder.Services.AddMapping().AddDataLayer(configuration).AddAuthLayer(configuration);
builder.Services.AddTransient<IImageUploaderService, ImageUploaderService>();
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy",
        builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials().WithExposedHeaders("totalAmountOfRecords"));
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

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();


app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");


app.Run();
