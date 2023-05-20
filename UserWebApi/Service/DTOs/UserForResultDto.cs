
namespace UserWebApi.Service.DTOs
{
    public class UserForResultDto
	{
		public long Id { get; set; }	
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		//public ICollection<WalletResultDto> wallets { get; set; }
	}
}
