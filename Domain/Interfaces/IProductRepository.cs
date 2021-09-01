using Domain;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProductById(int id);
		List<Product> GetProductsByFilter(string name,
								string description,
								string price, string initialDate,
								string finalDate);
		Product Create(Product product);
		void Update(Product product);
	}
}
