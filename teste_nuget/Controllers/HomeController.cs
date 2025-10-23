using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using teste_nuget.Models;

using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Microsoft.AspNetCore.Hosting.Server;
using System.Collections.Generic;

namespace teste_nuget.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult Cadastrar()
        //{
        //    return View();
        //}

        //public IActionResult Editar()
        //{
        //    return View();
        //}
        public IActionResult Excluir()
        {
            return View();
        }
        //public IActionResult Listar()
        //{
        //    return View();
        //}

        [HttpPost]

        public IActionResult Excluir(int id, string senha, string usuario)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                ViewData["Message"] = "O nome do usuario e a senha não podem estar vazios.";
                return View();
            }
            string connectionString = "Server=localhost; Database = cad_login; Uid = root;Pwd= 123456;";
            string query = "DELETE FROM login WHERE usuario = @usuario AND senha = @senha AND id = @id";

            try
            {
                using var connection = new MySqlConnection(connectionString);
                using var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int linhasAfetadas = command.ExecuteNonQuery();

                ViewData["Message"] = linhasAfetadas > 0
                    ? "Usuario excluido com sucesso!"
                    : "Ocorreu um erro e o usuario não foi cadastrado.";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"ERRO de banco de dados:{ex.Message}";
            }
            return View();
        }
        //LISTAR//
        //LISTA//
        //public IActionResult Listar(int id, string senha, string usuario)
        //{
        //    string connectionString = "Server=localhost; Database = cad_login; Uid = root;Pwd= 123456;";
        //    string query = "SELECT * FROM login WHERE id = @id";

        //    try
        //    {
        //        using var connection = new MySqlConnection(connectionString);
        //        using var command = new MySqlCommand(query, connection);

        //        command.Parameters.AddWithValue("@id", id);
        //        connection.Open();

        //        using var reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            ViewData["Message"] = "Usuario encontrado";
        //            ViewData["UsuarioEncontrado"] = reader["usuario"].ToString();
        //            ViewData["SenhaEncontrada"] = reader["senha"].ToString();
        //        }
        //        else
        //        {
        //            ViewData["Message"] = "Usuario nao encontrado";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["Message"] = $"ERRO de banco de dados:{ex.Message}";
        //    }
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


















