using Domain;

namespace Application.ViewModels
{
	public class OrderItemViewModel
	{
		public int UserId { get; set; }
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
