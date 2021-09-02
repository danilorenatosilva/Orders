using System.Collections.Generic;

namespace Application.ViewModels
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public List<OrderItemViewModel> Products { get; set; }
	}
}
