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
			IAccountService accountService)
		{
			_userService = userService;
			_accountService = accountService;
		}

		[HttpPost("signin")]
		public async Task<IActionResult> SignIn([FromBody] LoginUserViewModel loginUserViewModel)
		{
			var user = await _accountService.Login(loginUserViewModel);
			if (user == null)
			{
				return Unauthorized("Username or password are invalid");
			}

			return Ok(user);
		}

		[HttpPost("signup")]
		public async Task<IActionResult> SignUp([FromBody] RegisterUserViewModel registerUserViewModel)
		{
			if (_userService.UserExists(registerUserViewModel.UserName))
			{
				return BadRequest("Username already exists");
			}

			if (_userService.EmailExists(registerUserViewModel.Email))
			{
				return BadRequest("Email already exists");
			}

			var user = await _accountService.Register(registerUserViewModel);

			return Ok(user);
		}
	}
}
