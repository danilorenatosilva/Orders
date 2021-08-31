using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		private readonly IMapper _mapper;

		public OrderService(IOrderRepository repositorio, IMapper mapper)
		{
			_repository = repositorio;
			_mapper = mapper;
		}

		public OrderViewModel Create(OrderViewModel orderViewModel)
		{
			Order order = _mapper.Map<Order>(orderViewModel);
			order = _repository.Create(order);
			return _mapper.Map<OrderViewModel>(order);
		}

		public OrderViewModel GetOrderById(int id)
		{
			return _mapper.Map<OrderViewModel>(_repository.GetOrderById(id));
		}

		public IEnumerable<OrderViewModel> GetOrders()
		{
			var orders = _repository.GetOrders().ToList();
			return _mapper.Map<List<OrderViewModel>>(orders);
		}

		public void Update(OrderViewModel orderViewModel)
		{
			Order order = _mapper.Map<Order>(orderViewModel);
			_repository.Update(order);
		}
	}
}
