using DominioCleanArch;
using DominioCleanArch.Interfaces;
using InfraCleanArch.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfraCleanArch.Repositorios
{
	public class ProdutoRepositorio : IProdutoRepositorio
	{
		public readonly DaniloRenatoCommerceDbContext _contexto;

		public ProdutoRepositorio(DaniloRenatoCommerceDbContext contexto)
		{
			_contexto = contexto;
		}

		public Produto GetProdutoById(int id)
		{
			return _contexto.Produtos.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Produto> GetProdutos()
		{
			return _contexto.Produtos.ToList();
		}

		public Produto Create(Produto produto)
		{
			_contexto.Add(produto);
			_contexto.SaveChanges();
			return produto;
		}

		public void Update(Produto produto)
		{			
			_contexto.Entry(produto).State = EntityState.Modified;
			_contexto.SaveChanges();
		}

		public void Delete(int id)
		{
			var produto = GetProdutoById(id);
			if (produto == null)
			{
				throw new Exception("Produto não encontrado no banco de dados");
			}
			_contexto.Remove(produto);
			_contexto.SaveChanges();
		}

		public IEnumerable<Produto> GetProdutosByIdCategoria(int idCategoria)
		{
			return _contexto.Produtos.Where(p => p.IdCategoria == idCategoria).ToList();
		}
	}
}
