using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("/")]
	public class HomeController : ControllerBase
	{
		public string Index()
		{
			return "Orders API";
		}
	}
}
