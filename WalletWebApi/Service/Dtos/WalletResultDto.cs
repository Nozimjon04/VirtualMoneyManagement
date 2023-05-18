using WalletWebApi.Domain.Enums;

namespace WalletWebApi.Service.Dtos
{
	public class WalletResultDto
	{
		public long Id { get; set; }
		public long UserId { get; set; }
		public decimal Amount { get; set; }
		public DateTime? TransactionDate { get; set; }
		public TransactionType Type { get; set; }
		public string Description { get; set; }
	}
}
