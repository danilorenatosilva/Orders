using System.Collections.Generic;

namespace Application.ViewModels
{
	public class OrderViewModel
	{
		public int UserId { get; set; }
		public List<OrderItemViewModel> Products { get; set; }
	}
}
