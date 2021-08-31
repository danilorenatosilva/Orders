using Domain;
using Dominio.Interfaces;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly DatabaseContext _context;

		public ProductRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Product Create(Product product)
		{
			product.CreatedAt = DateTime.Now;
			_context.Products.Add(product);
			return product;
		}

		public Product GetProductById(int id)
		{
			return _context.Products.FirstOrDefault(p => p.Id == id);
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
