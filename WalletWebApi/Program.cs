using Microsoft.EntityFrameworkCore;
using WalletWebApi.DAL.Contexts;
using WalletWebApi.DAL.IRepositories;
using WalletWebApi.DAL.Repositories;
using WalletWebApi.Mappers;
using WalletWebApi.Service.Interfaces;
using WalletWebApi.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IWalletRepository<>), typeof(WalletRepository<>));
builder.Services.AddScoped<IWalletService, WalletService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add MappingProfile
builder.Services.AddAutoMapper(typeof(MappingProfile));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
