using System.Collections.Generic;

namespace Domain
{
	public class Order : Entity
	{
		public int UserId { get; set; }
		public List<Product> Products { get; set; }
	}
}
