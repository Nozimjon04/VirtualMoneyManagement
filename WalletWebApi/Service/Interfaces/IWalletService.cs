using System.Linq.Expressions;
using WalletWebApi.Domain.Models;
using WalletWebApi.Service.Dtos;

namespace WalletWebApi.Service.Interfaces
{
	public interface IWalletService
	{
		public Task<WalletResultDto> CreateAsync(WalletCreationDto dto);
		public Task<WalletResultDto> UpdateAsync(long id,WalletCreationDto dto);
		public Task<bool> DeleteAsync(long id);
		public Task<WalletResultDto> GetByIdAsync(long id);
		public Task<List<WalletResultDto>> GetAllAsync(Expression<Func<Wallet, bool>> expression = null,string search = null);
	}
}
