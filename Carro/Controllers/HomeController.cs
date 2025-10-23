using System.Diagnostics;
using Carro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int ano, string modelo, float preco )
        { 
            ViewBag.ano = ano;
            ViewBag.modelo = modelo;
            ViewBag.preco = preco;
            return View("VisualizarCarro");
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
