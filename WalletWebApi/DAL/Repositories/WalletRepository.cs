﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WalletWebApi.DAL.Contexts;
using WalletWebApi.DAL.IRepositories;
using WalletWebApi.Domain.Commons;

namespace WalletWebApi.DAL.Repositories
{
	public class WalletRepository<TEntity> : IWalletRepository<TEntity> where TEntity : Auditable
	{
		private readonly AppDbContext dbContext;
		private readonly DbSet<TEntity> dbSet;

		public WalletRepository(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
			this.dbSet = dbContext.Set<TEntity>();
		}

		public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
		{
			var user = await this.dbSet.FirstOrDefaultAsync(expression);
			if (user is null)
			{
				return false;
			}

			this.dbSet.Remove(user);
			return true;
		}

		public async Task<TEntity> InsertAsync(TEntity entity)
			=> (await this.dbSet.AddAsync(entity)).Entity;


		public async Task<bool> SaveChangeAsync()
			=> await dbContext.SaveChangesAsync() > 0;
		

		public IQueryable<TEntity> SelectAllAsync(Expression<Func<TEntity, bool>> expression = null)
		{
			var query = expression is null ? dbSet : dbSet.Where(expression);
			return query;
		}

		public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await this.dbSet.FirstOrDefaultAsync(expression);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
			=> (this.dbSet.Update(entity)).Entity;
		
	}
}
