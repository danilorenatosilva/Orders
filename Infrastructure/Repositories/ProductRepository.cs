using Domain;
using Dominio.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly OrdersDbContext _context;

		public ProductRepository(OrdersDbContext context)
		{
			_context = context;
		}

		public Product Create(Product product)
		{
			product.CreatedAt = DateTime.Now;
			_context.Products.Add(product);
			_context.SaveChanges();
			return product;
		}

		public Product GetProductById(int id)
		{
			return _context.Products.FirstOrDefault(p => p.Id == id);
		}

		public List<Product> GetProductsByFilter(string name,
								string description,
								string priceString, string initialDateString,
								string finalDateString)
		{
			DateTime? initialDate = null;
			DateTime? finalDate = null;
			decimal? price = null;

			if (!string.IsNullOrWhiteSpace(initialDateString) && !string.IsNullOrWhiteSpace(finalDateString))
			{
				initialDate = DateTime.Parse(initialDateString);
				finalDate = DateTime.Parse(finalDateString);
			}

			if (!string.IsNullOrWhiteSpace(priceString))
			{
				price = decimal.Parse(priceString);
			}

			return GetProducts()
				.Where(p => (string.IsNullOrWhiteSpace(name) ||
								(!string.IsNullOrWhiteSpace(name) &&
								p.Name.ToLower().Equals(name.ToLower())))
						&&
							(string.IsNullOrWhiteSpace(description) ||
								(!string.IsNullOrWhiteSpace(description) &&
								p.Description.ToLower().Contains(description.ToLower())))
						&& (price == null ||
								(price != null && p.Price == price))
						&& ((initialDate == null || finalDate == null) ||
								((initialDate != null && finalDate != null) &&
								(p.CreatedAt >= initialDate && p.CreatedAt <= finalDate)))
						)
				.ToList();
		}

		public IEnumerable<Product> GetProducts()
		{
			return _context.Products.ToList();
		}

		public void Update(Product product)
		{
			_context.Entry(product).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
