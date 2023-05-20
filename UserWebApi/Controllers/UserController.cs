using Microsoft.AspNetCore.Mvc;
using UserWebApi.Helpers;
using UserWebApi.Service.DTOs;
using UserWebApi.Service.Interfaces;

namespace UserWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateUserAsync(UserCreationDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.CreateAsync(dto)
			});
		[HttpDelete("delete/{id:long}")]
		public async Task<IActionResult> DelateUserAsync(int id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.DeleteAsync(id)
			});
		[HttpPut("Update")]
		public async Task<IActionResult> UpdateUserAsync(long id, UserCreationDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.UpdateAsync(id, dto)
			});
		[HttpGet("get-by-id{id:long}")]
		public async Task<IActionResult> GetByIdAsync(long id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.GetByIdAsync(id)
			});
		[HttpGet("get-list")]
		public async Task<IActionResult> GetAllUsers()
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.GetAllAsync()
			});
	}
}
