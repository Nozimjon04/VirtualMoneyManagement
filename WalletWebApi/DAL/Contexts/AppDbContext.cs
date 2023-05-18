using Microsoft.EntityFrameworkCore;
using WalletWebApi.Domain.Models;

namespace WalletWebApi.DAL.Contexts
{
	public class AppDbContext :DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{ }
		DbSet<Wallet> Wallets { get; set; }
	}
}
