using AutoMapper;
using System.Linq.Expressions;
using WalletWebApi.DAL.IRepositories;
using WalletWebApi.Domain.Models;
using WalletWebApi.Service.Dtos;
using WalletWebApi.Service.Exceptions;
using WalletWebApi.Service.Interfaces;

namespace WalletWebApi.Service.Services
{
	public class WalletService : IWalletService
	{
		private readonly IMapper mapper;
		private readonly IWalletRepository<Wallet> walletRepository;
		public WalletService(IMapper mapper, IWalletRepository<Wallet> walletRepository)
		{
			this.mapper = mapper;
			this.walletRepository = walletRepository;
		}
		public async Task<WalletResultDto> CreateAsync(WalletCreationDto dto)
		{
			var  wallet = await this.walletRepository.SelectAsync(w => w.UserId == dto.UserId);
			if (wallet is not null)
				throw new CustomException(409, "This user has already WalletAccount");

			var mappedWalled = this.mapper.Map<Wallet>(dto);
			mappedWalled.CreateAt = DateTime.UtcNow;
			var result = await this.walletRepository.InsertAsync(mappedWalled);
			await walletRepository.SaveChangeAsync();

			return this.mapper.Map<WalletResultDto>(result);
		}

		public async Task<bool> DeleteAsync(long id)
		{
			var result = await walletRepository.DeleteAsync(w => w.Id == id);
			if (!result)
				throw new CustomException(404, "Wallet is not found");

			return true;
		}

		public async Task<List<WalletResultDto>> GetAllAsync(Expression<Func<Wallet, bool>> expression=null, string search = null)
		{
			var wallets = this.walletRepository.SelectAllAsync(expression);
			if (!string.IsNullOrEmpty(search))
			{
				wallets = wallets.Where(w => w.Description.ToLower().Contains(search.ToLower()));
			}
				return this.mapper.Map<List<WalletResultDto>>(wallets);
		}

		public async Task<WalletResultDto> GetByIdAsync(long id)
		{
			var wallet = await this.walletRepository.SelectAsync(w => w.Id == id);
			if (wallet is null)
				throw new CustomException(404, "Wallet is not found");
			return this.mapper.Map<WalletResultDto>(wallet);
		}

		public async Task<WalletResultDto> UpdateAsync(long id, WalletCreationDto dto)
		{
			var wallet = await this.walletRepository.SelectAsync(w => w.Id == id);
			if (wallet is null)
				throw new CustomException(404, "Wallet is not found");
			var result = this.mapper.Map(dto,wallet);
			result.Id = id;
			result.UpdateAt = DateTime.UtcNow;
			await walletRepository.SaveChangeAsync();

			return this.mapper.Map<WalletResultDto>(result);
		}
	}
}
