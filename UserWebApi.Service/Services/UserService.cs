using AutoMapper;
using System.Linq.Expressions;
using UserWebApi.Service.DTOs;
using UserWebApi.Service.Exceptions;
using UserWebApi.UserWebApi.Data.IRepositories;
using UserWebApi.UserWebApi.Domain.Models;
using UserWebApi.UserWebApi.Service.Interfaces;

namespace UserWebApi.UserWebApi.Service.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper mapper;
		private readonly IUserRepository<User> userRepository;

		public UserService(IMapper mapper,
			IUserRepository<User> userRepository
			)
		{
			this.mapper = mapper;
			this.userRepository = userRepository;
		}
		public async Task<UserForResultDto> CreateAsync(UserCreationDto dto)
		{
			var user = await this.userRepository.SelectAsync(u => u.Email.ToLower() == dto.Email.ToLower());
			if (user is not null)
				throw new CustomException(409, " User is already exists");

			var mappedUser = this.mapper.Map<User>(dto);
			mappedUser.CreateAt = DateTime.UtcNow;
			var result = await this.userRepository.InsertAsync(mappedUser);
			await this.userRepository.SaveChangeAsync();

			return this.mapper.Map<UserForResultDto>(result);
		}

		public async Task<bool> DeleteAsync(long id)
		{
			var result = await this.userRepository.DeleteAsync(u => u.Id == id);
			await this.userRepository.SaveChangeAsync();

			return result;
		}


		public async Task<List<UserForResultDto>> GetAllAsync(Expression<Func<User, bool>> expression = null, string search = null)
		{
			var users = this.userRepository.SelectAllAsync(expression);
			if (!string.IsNullOrEmpty(search))
			{
				users = users.Where(u => u.Name.ToLower().Contains(search.ToLower()) ||
					u.Surname.ToLower().Contains(search.ToLower()));
			}

			return this.mapper.Map<List<UserForResultDto>>(users);
		}

		public async Task<UserForResultDto> GetByIdAsync(long id)
		{
			var user = await this.userRepository.SelectAsync(u => u.Id == id);
			if (user is null)
				throw new CustomException(404, "User is not found ");
			var result = this.mapper.Map<UserForResultDto>(user);

			return result;
		}

		public async Task<User> RetrieveByEmailAsync(string email)
			=> await this.userRepository.SelectAsync(u => u.Email == email);


		public async Task<UserForResultDto> UpdateAsync(long id, UserCreationDto dto)
		{
			var user = await this.userRepository.SelectAsync(u => u.Id == id);
			if (user is null)
				throw new CustomException(404, "User is not found ");

		;
			var result = this.mapper.Map(dto, user);
			result.Id = id;
			result.UpdateAt = DateTime.UtcNow;
			await this.userRepository.SaveChangeAsync();

			return this.mapper.Map<UserForResultDto>(result);
		}
	}
}	
