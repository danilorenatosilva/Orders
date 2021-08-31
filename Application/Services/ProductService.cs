using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Servicos
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository repositorio, IMapper mapper)
		{
			_repository = repositorio;
			_mapper = mapper;
		}

		public ProductViewModel Create(ProductViewModel productViewModel)
		{
			Product product = _mapper.Map<Product>(productViewModel);
			return _mapper.Map<ProductViewModel>(_repository.Create(product));
		}

		public ProductViewModel GetProductById(int id)
		{
			return _mapper.Map<ProductViewModel>(_repository.GetProductById(id));
		}

		public IEnumerable<ProductViewModel> GetProducts()
		{
			return _mapper.Map<List<ProductViewModel>>(_repository.GetProducts().ToList());
		}

		public void Update(ProductViewModel productViewModel)
		{
			Product product = _mapper.Map<Product>(productViewModel);
			_repository.Update(product);
		}
	}
}
