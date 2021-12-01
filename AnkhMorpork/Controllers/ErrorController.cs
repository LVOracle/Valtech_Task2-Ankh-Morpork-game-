using Microsoft.AspNetCore.Mvc;

namespace AnkhMorpork.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
