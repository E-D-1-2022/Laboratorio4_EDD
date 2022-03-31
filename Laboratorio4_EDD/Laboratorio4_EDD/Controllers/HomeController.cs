using Laboratorio4_EDD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio4_EDD.DataBase;
using Laboratorio4_EDD.DTO;
namespace Laboratorio4_EDD.Controllers
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
        public IActionResult Formulario() {
            ViewData["ListaEsp"] = DataBase.DataBase.Especializacion;
            ViewData["ListaIngreso"] = DataBase.DataBase.Ingreso;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
