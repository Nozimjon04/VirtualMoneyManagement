namespace WalletWebApi.Service.Exceptions
{
	public class CustomException :Exception
	{
		public int Code { get; set; }
		public CustomException(int Code,string message) : base(message) 
		{
			this.Code= Code;
		}

	}
}
