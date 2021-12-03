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
                var player = new Player(model.Name){UserName = model.Name};
                var result = await _playerManager.CreateAsync(player, model.Password);
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
            var player = await _playerManager.FindByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            var model = new EditPlayerViewModel { Id = player.Id, Name = player.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var player = await _playerManager.FindByIdAsync(model.Id);
                if (player != null)
                {
                    player.Name = model.Name;

                    var result = await _playerManager.UpdateAsync(player);
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
            var player = await _playerManager.FindByIdAsync(id);
            if (player != null)
            {
                IdentityResult result = await _playerManager.DeleteAsync(player);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangePassword(string id)
        {
            var player = await _playerManager.FindByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = player.Id, Name = player.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var player = await _playerManager.FindByIdAsync(model.Id);
                if (player != null)
                {
                    IdentityResult result =
                        await _playerManager.ChangePasswordAsync(player, model.OldPassword, model.NewPassword);
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
                else
                {
                    ModelState.AddModelError(string.Empty, "Player not found");
                }
            }
            return View(model);
        }
    }
}

