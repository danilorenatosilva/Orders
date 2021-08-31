using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using AutoMapper;
using DominioCleanArch;
using DominioCleanArch.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AplicacaoCleanArch.Servicos
{
	public class ProdutoServico : IProdutoServico
	{
		private readonly IProdutoRepositorio _repositorio;
		private readonly IMapper _mapper;

		public ProdutoServico(IProdutoRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public ProdutoViewModel Create(ProdutoViewModel produtoViewModel)
		{
			Produto produto = _mapper.Map<Produto>(produtoViewModel);
			return _mapper.Map<ProdutoViewModel>(_repositorio.Create(produto));
		}

		public void Delete(int id)
		{
			_repositorio.Delete(id);
		}

		public ProdutoViewModel GetProdutoById(int id)
		{
			return _mapper.Map<ProdutoViewModel>(_repositorio.GetProdutoById(id));
		}

		public IEnumerable<ProdutoViewModel> GetProdutos()
		{
			return _mapper.Map<List<ProdutoViewModel>>(_repositorio.GetProdutos().ToList());
		}

		public IEnumerable<ProdutoViewModel> GetProdutosByIdCategoria(int idCategoria)
		{
			return _mapper.Map<List<ProdutoViewModel>>(_repositorio.GetProdutosByIdCategoria(idCategoria));
		}

		public void Update(ProdutoViewModel produtoViewModel)
		{
			Produto produto = _mapper.Map<Produto>(produtoViewModel);
			_repositorio.Update(produto);
		}
	}
}
