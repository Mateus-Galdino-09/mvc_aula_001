using System.Diagnostics;
using atv_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace atv_05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Index(string nomecontato, string sobrenome, int telefone, int idade)
        {
            ViewBag.nomecontato = nomecontato;
            ViewBag.sobrenome = sobrenome;
            ViewBag.telefone = telefone;
            ViewBag.idade = idade ;

            return View("bd_contatos");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
