using WalletWebApi.Domain.Commons;
using WalletWebApi.Domain.Enums;

namespace WalletWebApi.Domain.Models
{
    public class Wallet:Auditable
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
    }
}
