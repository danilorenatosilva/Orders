using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Apresentacao.Controllers
{
	public class CategoriasController : Controller
	{
		private IWebHostEnvironment _hostEnvironment;

		public CategoriasController(IWebHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		public ActionResult Index()
		{
			var diretorioRootImagens = Path.Combine(_hostEnvironment.WebRootPath, "imagens");
			ViewData["diretorioRootImagens"] = diretorioRootImagens;
			return View();
		}
	}
}
