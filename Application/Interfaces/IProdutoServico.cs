using AplicacaoCleanArch.ViewModels;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Interfaces
{
	public interface IProdutoServico
	{
		IEnumerable<ProdutoViewModel> GetProdutos();
		ProdutoViewModel GetProdutoById(int id);
		IEnumerable<ProdutoViewModel> GetProdutosByIdCategoria(int idCategoria);
		ProdutoViewModel Create(ProdutoViewModel produto);
		void Update(ProdutoViewModel produto);
		void Delete(int id);
	}
}
