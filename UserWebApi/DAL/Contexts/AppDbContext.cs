﻿using Microsoft.EntityFrameworkCore;
using UserWebApi.UserWebApi.Domain.Models;

namespace UserWebApi.DAL.Contexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{ }
		DbSet<User> Users { get; set; }
	}
}
