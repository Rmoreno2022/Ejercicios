using Microsoft.AspNetCore.Mvc;

namespace Ejercicios.Web.Controllers
{
    public class StopwatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
