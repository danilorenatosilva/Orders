using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetOrders()
		{
			try
			{
				return Ok(_orderService.GetOrders());
			}
			catch
			{
				return StatusCode(500);
			}
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody]OrderViewModel orderViewModel)
		{
			try
			{
				return Ok(_orderService.Create(orderViewModel));
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
