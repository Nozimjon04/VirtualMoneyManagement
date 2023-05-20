using System.Linq.Expressions;
using UserWebApi.Service.DTOs;
using UserWebApi.UserWebApi.Domain.Models;

namespace UserWebApi.UserWebApi.Service.Interfaces
{
	public interface IUserService
	{
		public Task<UserForResultDto> CreateAsync(UserCreationDto dto);
		public Task<UserForResultDto> UpdateAsync(long id, UserCreationDto dto);
		public Task<bool> DeleteAsync(long id);
		public Task<UserForResultDto> GetByIdAsync(long id);
		Task<User> RetrieveByEmailAsync(string email);
		public Task<List<UserForResultDto>> GetAllAsync(Expression<Func<User, bool>> expression = null, string search = null);
	}
}
