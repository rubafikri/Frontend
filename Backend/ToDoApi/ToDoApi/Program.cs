using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Interfaces;
using ToDoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IToDo, ToDoReposeitery>();
builder.Services.AddScoped<ITodCatergory, TodoCategoryRepo>();

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


app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseAuthorization();

app.MapControllers();

app.Run();
