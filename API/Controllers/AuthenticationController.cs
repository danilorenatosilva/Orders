using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IAccountService _accountService;

		public AuthenticationController(IUserService userService, 
			IMapper mapper, IConfiguration configuration, 
			IAccountService accountService)
		{
			_userService = userService;
			_accountService = accountService;
		}

		[HttpPost("signin")]
		public async Task<IActionResult> SignIn([FromBody] LoginUserViewModel loginUserViewModel)
		{
			await _accountService.Login(loginUserViewModel);
			return Ok(loginUserViewModel);
		}

		[HttpPost("signup")]
		public async Task<IActionResult> SignUp([FromBody] RegisterUserViewModel registerUserViewModel)
		{
			await _accountService.Register(registerUserViewModel);

			return Ok();
		}
	}
}
