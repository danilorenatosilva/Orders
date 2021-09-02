namespace Domain
{
	public class OrderItem : Entity
	{
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
