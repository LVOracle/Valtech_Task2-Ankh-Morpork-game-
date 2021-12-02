using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Valtech_Task2_Ankh_Morpork_game_;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.IRepository;

namespace AnkhMorpork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeneralRepository _repository;
        public HomeController(ILogger<HomeController> logger, AnkhMorporkGameContext context, IGeneralRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
            if(!context.Assassins.Any())
                DbSeedData.SeedData(context);
        }

        public IActionResult Index()
        {
            return View(_repository);
        }
    }
}
