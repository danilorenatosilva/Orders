using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IProductService
	{
		IEnumerable<ProductViewModel> GetProducts();
		ProductViewModel GetProductById(int id);
		ProductViewModel Create(ProductViewModel product);
		void Update(ProductViewModel product);
	}
}
