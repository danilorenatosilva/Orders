using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetProductsByFilter([FromQuery] string name, 
								string description, 
								string price, string initialDate, 
								string finalDate)
		{


			return Ok();
		}
	}
}
