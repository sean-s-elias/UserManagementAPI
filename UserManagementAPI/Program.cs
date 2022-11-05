using Application.Interfaces;
using Application.Query;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

/// <summary>
/// //Connection to DB
/// </summary>
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddMediatR(typeof(UserQuery));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    /*app.UseSwagger();
    app.UseSwaggerUI();*/
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
