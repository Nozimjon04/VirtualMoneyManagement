using AutoMapper;
using WalletWebApi.Domain.Models;
using WalletWebApi.Service.Dtos;

namespace WalletWebApi.Mappers
{
	public class MappingProfile: Profile
	{
		public MappingProfile()
		{
			CreateMap<Wallet, WalletCreationDto>().ReverseMap();
			CreateMap<Wallet, WalletResultDto>().ReverseMap();
		}
	}
}
