using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Valtech_Task2_Ankh_Morpork_game_;
using Valtech_Task2_Ankh_Morpork_game_.Data;

namespace AnkhMorpork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnkhMorporkGameContext _context;
        public HomeController(ILogger<HomeController> logger, AnkhMorporkGameContext context)
        {
            _logger = logger;
            _context = context;
            if(!context.Assassins.Any())
                DbSeedData.SeedData(context);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
