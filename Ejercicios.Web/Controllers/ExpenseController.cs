using Microsoft.AspNetCore.Mvc;
using Ejercicios.Web.Services.Abstractions;
using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseCategoryService _categoryService;

        public ExpenseController(
            IExpenseService expenseService,
            IExpenseCategoryService categoryService)
        {
            _expenseService = expenseService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _expenseService.GetAllAsync();
            ViewBag.Total = items.Sum(x => x.Amount);

            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(new ExpenseDTO { Date = DateTime.Today });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllAsync();
                return View(model);
            }

            await _expenseService.AddAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MonthlySummary(int year, int month)
        {
            var items = await _expenseService.GetMonthlyAsync(year, month);

            ViewBag.Total = items.Sum(x => x.Amount);

            return View(items);
        }
    }
}
