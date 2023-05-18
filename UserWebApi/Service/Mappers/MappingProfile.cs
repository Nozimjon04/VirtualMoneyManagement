using AutoMapper;
using UserWebApi.Service.DTOs;
using UserWebApi.UserWebApi.Domain.Models;

namespace UserWebApi.Service.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// user
			CreateMap<User, UserCreationDto>().ReverseMap();
			CreateMap<User, UserForResultDto>().ReverseMap();
		}
	}
}
