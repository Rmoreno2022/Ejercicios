using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;


namespace Ejercicios.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _service.GetAllAsync();
            return View(reservations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ReservationDTO { Date = DateTime.Today });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationDTO dto)
        {
            bool ok = await _service.CreateAsync(dto);

            if (!ok)
            {
                ModelState.AddModelError("", "El horario ya está ocupado.");
                return View(dto);
            }

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
