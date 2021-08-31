using System.Collections.Generic;

namespace DominioCleanArch.Interfaces
{
	public interface IProdutoRepositorio
	{
		IEnumerable<Produto> GetProdutos();
		Produto GetProdutoById(int id);
		IEnumerable<Produto> GetProdutosByIdCategoria(int idCategoria);
		Produto Create(Produto produto);
		void Update(Produto produto);
		void Delete(int id);
	}
}
