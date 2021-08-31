using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Apresentacao.Controllers
{
	public class ProdutosController : Controller
	{
		private IWebHostEnvironment _hostEnvironment;

		public ProdutosController(IWebHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		public IActionResult Index()
		{
			var diretorioRootImagens = Path.Combine(_hostEnvironment.WebRootPath, "imagens");
			ViewData["diretorioRootImagens"] = diretorioRootImagens;
			return View();
		}
	}
}
