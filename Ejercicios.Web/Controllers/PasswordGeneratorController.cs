using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Controllers
{
    public class PasswordGeneratorController : Controller
    {
        private readonly IPasswordGeneratorService _service;

        public PasswordGeneratorController(IPasswordGeneratorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new PasswordGeneratorDTO());
        }

        [HttpPost]
        public IActionResult Index(PasswordGeneratorDTO settings)
        {
            string password = _service.Generate(settings);
            settings.GeneratedPassword = password;
            return View("Result", settings);
        }
    }
}
