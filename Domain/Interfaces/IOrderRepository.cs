using System.Collections.Generic;

namespace Domain.Interfaces
{
	public interface IOrderRepository
	{
		IEnumerable<Order> GetOrders();
		Order GetOrderById(int id);
		Order Create(Order order);
		void Update(Order order);
	}
}
