using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Controllers
{
    public class EventCalendarController : Controller
    {
        private readonly IEventService _service;

        public EventCalendarController(IEventService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
            var selectedDate = date ?? DateTime.Today;
            ViewBag.SelectedDate = selectedDate;

            var events = await _service.GetEventsByDateAsync(selectedDate);

            return View(events);
        }

        public IActionResult Create(DateTime date)
        {
            return View(new EventDTO
            {
                StartDate = date,
                EndDate = date
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventDTO dto)
        {
            await _service.CreateAsync(dto);
            return RedirectToAction("Index", new { date = dto.StartDate.Date });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventDTO dto)
        {
            await _service.UpdateAsync(dto);
            return RedirectToAction("Index", new { date = dto.StartDate.Date });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            await _service.DeleteAsync(id);

            return RedirectToAction("Index", new { date = dto.StartDate.Date });
        }
    }
}
