using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IProductService
	{
		IEnumerable<ProductViewModel> GetProducts();
		ProductViewModel GetProductById(int id);
		List<ProductViewModel> GetProductsByFilter(string name,
								string description,
								string priceString, string initialDateString,
								string finalDateString);
		ProductViewModel Create(ProductViewModel product);
		void Update(ProductViewModel product);
	}
}
