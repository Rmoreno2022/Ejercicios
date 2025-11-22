using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Controllers
{
    public class TipController : Controller
    {
        private readonly ITipService _service;

        public TipController(ITipService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TipDTO());
        }

        [HttpPost]
        public IActionResult Index(TipDTO model)
        {
            if (model.BillAmount <= 0)
                ModelState.AddModelError("", "El monto debe ser mayor a cero.");

            if (!ModelState.IsValid)
                return View(model);

            var result = _service.Calculate(model.BillAmount, model.TipPercentage);
            return View("Result", result);
        }
    }
}
