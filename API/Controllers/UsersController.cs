﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetUsersByFilter([FromQuery]string userName, 
														string fullDisplayName, 
														string email,
														string initialDate, string finalDate)
		{
			if (!string.IsNullOrEmpty(initialDate) && (!DateTime.TryParse(initialDate, out DateTime initialDateParameter)) ||
			   (!string.IsNullOrEmpty(finalDate) && !DateTime.TryParse(finalDate, out DateTime finalDateParameter)))
				return BadRequest();


			return Ok();
		}
	}
}
