using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _service;

        public RecipesController(IRecipeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? search, int? categoryId)
        {
            ViewBag.Search = search;
            ViewBag.Categories = await _service.GetCategoriesAsync();
            ViewBag.CategoryId = categoryId;

            var recipes = await _service.GetAllAsync(search, categoryId);
            return View(recipes);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _service.GetCategoriesAsync();
            return View(new RecipeDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeDTO dto)
        {
            await _service.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();

            ViewBag.Categories = await _service.GetCategoriesAsync();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeDTO dto)
        {
            await _service.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
