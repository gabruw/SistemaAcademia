using System.Diagnostics;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Smartgym.Models;

namespace Smartgym.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public HomeController(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public IActionResult Index()
        {
            var unidadesDTO = _unidadeRepository.GetAll();

            return View();
        }

        public IActionResult Assinar()
        {
            return View();
        }

        public IActionResult Main()
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
