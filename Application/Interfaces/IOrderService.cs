using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IOrderService
	{
		IEnumerable<OrderViewModel> GetOrders();
		OrderViewModel GetOrderById(int id);
		OrderViewModel Create(OrderViewModel order);
		void Update(OrderViewModel order);
	}
}
