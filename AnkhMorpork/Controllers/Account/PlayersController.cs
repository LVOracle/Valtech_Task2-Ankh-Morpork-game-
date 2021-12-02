using System.Linq;
using System.Threading.Tasks;
using AnkhMorpork.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Valtech_Task2_Ankh_Morpork_game_;

namespace AnkhMorpork.Controllers.Account
{
    public class PlayersController : Controller
    {
        private readonly UserManager<Player> _playerManager;

        public PlayersController(UserManager<Player> playerManager)
        {
            this._playerManager = playerManager;
        }

        public IActionResult Index() => View(_playerManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Player(model.Name);
                var result = await _playerManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _playerManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditPlayerViewModel { Id = user.Id, Name = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _playerManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Name = model.Name;

                    var result = await _playerManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _playerManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _playerManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}

