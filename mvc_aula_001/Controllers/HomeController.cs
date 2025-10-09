using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc_aula_001.Models;

namespace mvc_aula_001.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Cad_Pessoa(string nome, string sobrenome, int idade)
        {
            CPessoa cp = new CPessoa()
            {
                nome = nome,
                sobrenome = sobrenome,
                idade = idade
            };

             return View(cp);
        }
        public IActionResult Cad_Aluno(string nome, string sobrenome, int idade, double NumeroMatricula)
        {
            CAluno ca = new CAluno()
            {
                nome = nome,
                sobrenome = sobrenome,
                idade = idade,
                NumeroMatricula = NumeroMatricula

            };
            return View(ca);
        }
        public IActionResult Reg_Bib(string TitloLivro, string NomeAutor, int AnoPublicacao, int NumeroPaginas) 
        {
            RBib rb = new RBib()
            {
                TituloLivro = TitloLivro,
                NomeAutor = NomeAutor,
                AnoPublicacao = AnoPublicacao,
                NumeroPaginas = NumeroPaginas
            };
            return View(rb);
        }
        public IActionResult Cad_Pet(string NomePet, string Especie, string NomeDono, int IdadePet)
        {
            CPet cPet = new CPet()
            {
                NomePet = NomePet,
                Especie = Especie,
                NomeDono = NomeDono,
                IdadePet = IdadePet
            };
            return View(cPet);
        }
        public IActionResult Index(string nome, string cargo, int salario, int codigo)
        {
            ViewBag.nome = nome;
            ViewBag.cargo = cargo;
            ViewBag.salario = salario;
            ViewBag.codigo = codigo; 
            return View("bd_funcionario");
        }

           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
