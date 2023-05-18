using Microsoft.AspNetCore.Mvc;
using WalletWebApi.Helpers;
using WalletWebApi.Service.Dtos;
using WalletWebApi.Service.Interfaces;

namespace WalletWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WalletController : ControllerBase
	{
		private readonly IWalletService walletService;

		public WalletController(IWalletService walletService)
		{
			this.walletService = walletService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateWalletAsync(WalletCreationDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.walletService.CreateAsync(dto)
			});

		[HttpDelete("delete/{id:long}")]
		public async Task<IActionResult> DelateWalletAsync(int id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.walletService.DeleteAsync(id)
			});

		[HttpPut("Update")]
		public async Task<IActionResult> UpdateWalletAsync(long id, WalletCreationDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.walletService.UpdateAsync(id, dto)
			});

		[HttpGet("get-by-id{id:long}")]
		public async Task<IActionResult> GetByIdAsync(long id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.walletService.GetByIdAsync(id)
			});

		[HttpGet("get-list")]
		public async Task<IActionResult> GetAllWallets()
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",

				Data = await this.walletService.GetAllAsync()
			});
	}
}

