using System.Collections.Generic;

namespace DominioCleanArch.Interfaces
{
	public interface ICategoriaRepositorio
	{
		IEnumerable<Categoria> GetCategorias();
		Categoria GetCategoriaById(int id);
		Categoria Create(Categoria categoria);
		void Update(Categoria categoria);
		void Delete(int id);
	}
}
