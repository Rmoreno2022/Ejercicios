using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Data;

namespace Ejercicios.Web.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesService _service;
        private readonly DataContext _context;

        public NotesController(INotesService service, DataContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            ViewBag.Search = search;
            var notes = await _service.GetAllAsync(search);
            return View(notes);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.NoteCategories
                .Select(c => new NoteCategoryDTO { Id = c.Id, Name = c.Name })
                .ToList();

            return View(new NoteDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.NoteCategories
                    .Select(c => new NoteCategoryDTO { Id = c.Id, Name = c.Name })
                    .ToList();
                return View(dto);
            }

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var note = await _service.GetByIdAsync(id);
            if (note == null) return NotFound();

            ViewBag.Categories = _context.NoteCategories
                .Select(c => new NoteCategoryDTO { Id = c.Id, Name = c.Name })
                .ToList();

            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.NoteCategories
                    .Select(c => new NoteCategoryDTO { Id = c.Id, Name = c.Name })
                    .ToList();
                return View(dto);
            }

            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
