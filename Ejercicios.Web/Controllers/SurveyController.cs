using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyService _service;

        public SurveyController(ISurveyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new DTOs.SurveyDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DTOs.SurveyDTO dto)
        {
            await _service.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DTOs.SurveyDTO dto)
        {
            await _service.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return View(dto);
        }

        public async Task<IActionResult> Vote(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int optionId, int surveyId)
        {
            await _service.VoteAsync(optionId);

            // Redirige correctamente a resultados
            return RedirectToAction("Results", new { id = surveyId });
        }

        public async Task<IActionResult> Results(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
