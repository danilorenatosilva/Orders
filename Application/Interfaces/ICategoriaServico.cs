using AplicacaoCleanArch.ViewModels;
using DominioCleanArch;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Interfaces
{
	public interface ICategoriaServico
	{
		IEnumerable<CategoriaViewModel> GetCategorias();
		CategoriaViewModel GetCategoriaById(int id);
		CategoriaViewModel Create(CategoriaViewModel categoria);
		void Update(CategoriaViewModel categoria);
		void Delete(int id);
	}
}
