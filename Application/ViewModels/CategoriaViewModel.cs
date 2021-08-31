using Microsoft.AspNetCore.Http;

namespace AplicacaoCleanArch.ViewModels
{
	public class CategoriaViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string UrlImagem { get; set; }
		public string Descricao { get; set; }
		public IFormFile ArquivoImagem { get; set; }
		public string CaminhoFisicoImagens { get; set; }
	}
}
