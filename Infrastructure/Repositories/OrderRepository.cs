using Domain;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly OrdersDbContext _context;

		public OrderRepository(OrdersDbContext context)
		{
			_context = context;
		}

		public Order Create(Order product)
		{
			product.CreatedAt = DateTime.Now;
			_context.Orders.Add(product);
			_context.SaveChanges();
			return product;
		}

		public Order GetOrderById(int id)
		{
			return _context.Orders.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Order> GetOrders()
		{
			return _context.Orders.ToList();
		}

		public void Update(Order product)
		{
			_context.Entry(product).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
