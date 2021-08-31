using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationController : ControllerBase
	{
		[HttpPost("signin")]
		public IActionResult SignIn([FromBody] LoginUserViewModel loginUserViewModel)
		{
			return Ok(loginUserViewModel);
		}
	}
}
