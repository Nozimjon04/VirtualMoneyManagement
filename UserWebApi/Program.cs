using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using UserWebApi.DAL.Contexts;
using UserWebApi.DAL.IRepositories;
using UserWebApi.DAL.Repositories;
using UserWebApi.Helpers;
using UserWebApi.Middlewares;
using UserWebApi.Service.Interfaces;
using UserWebApi.Service.Mappers;
using UserWebApi.Service.Services;
using UserWebApi.UserWebApi.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
// Add MappingProfile
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Convert  Api url name to dash case 
builder.Services.AddControllers(options =>
	options.Conventions.Add(
		new RouteTokenTransformerConvention(new RouteConfiguration())));
// Database configuration
builder.Services.AddDbContext<AppDbContext>(option =>
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseAuthorization();

app.MapControllers();

app.Run();
