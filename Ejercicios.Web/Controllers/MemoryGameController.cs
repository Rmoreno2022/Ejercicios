using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Controllers
{
    public class MemoryGameController : Controller
    {
        private readonly IMemoryGameService _service;

        public MemoryGameController(IMemoryGameService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Play(int level = 1)
        {
            ViewBag.Level = level;
            ViewBag.Cards = await _service.GetCardsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveScore([FromBody] MemoryGameDTO dto)
        {
            await _service.SaveGameAsync(dto, "anon");
            return Ok();
        }

        public async Task<IActionResult> TopScores(int level)
        {
            var scores = await _service.GetTopScoresAsync(level);
            ViewBag.Level = level;
            return View(scores);
        }
    }
}
