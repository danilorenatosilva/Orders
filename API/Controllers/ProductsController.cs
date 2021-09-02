using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetProductsByFilter([FromQuery] string name, 
								string description, 
								string price, string initialDate, 
								string finalDate)
		{
			if ((!string.IsNullOrWhiteSpace(initialDate) && !DateTime.TryParse(initialDate, out DateTime initialDateTime))
				||
				(!string.IsNullOrWhiteSpace(finalDate) && !DateTime.TryParse(finalDate, out DateTime finalDateTime))
				||
				(!string.IsNullOrWhiteSpace(price) && !decimal.TryParse(price, out decimal priceValue))
			)
			{
				return BadRequest();
			}

			var products = _productService.GetProductsByFilter(name, description, price, initialDate, finalDate);

			return Ok(products);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody] ProductViewModel productViewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			try
			{
				var product = _productService.Create(productViewModel);
				return Ok(product);
			}
			catch
			{
				return StatusCode(500);
			}
		}

		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> Update(int id, [FromBody] ProductViewModel productViewModel)
		{
			if (id != productViewModel.Id)
				return BadRequest();

			try
			{
				_productService.Update(productViewModel);
				return NoContent();
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
