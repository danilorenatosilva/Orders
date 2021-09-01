using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

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
		public IActionResult GetProductsByFilter([FromQuery] string name, 
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
		public IActionResult Create([FromBody] ProductViewModel productViewModel)
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
	}
}
