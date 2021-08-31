using Domain;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProductById(int id);
		Product Create(Product product);
		void Update(Product product);
	}
}
