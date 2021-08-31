using Microsoft.AspNetCore.Http;

namespace AplicacaoCleanArch.ViewModels
{
	public class ProdutoViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string UrlImagem { get; set; }
		public decimal PrecoUnitario { get; set; }
		public int IdCategoria { get; set; }
		public IFormFile ArquivoImagem { get; set; }
		public string CaminhoFisicoImagens { get; set; }
	}
}
