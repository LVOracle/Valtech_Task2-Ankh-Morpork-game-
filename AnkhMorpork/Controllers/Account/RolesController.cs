using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkhMorpork.ViewModels;
using Valtech_Task2_Ankh_Morpork_game_;

namespace AnkhMorpork.Controllers.Account
{
    public class RolesController : Controller
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<Player> _playerManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<Player> playerManager)
        {
            _roleManager = roleManager;
            _playerManager = playerManager;
        }
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
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
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult PlayersList() => View(_playerManager.Users.ToList());

        public async Task<IActionResult> Edit(string userId)
        {
            var player = await _playerManager.FindByIdAsync(userId);
            if (player != null)
            {
                var playerRole = await _playerManager.GetRolesAsync(player);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new()
                {
                    PlayerId = player.Id,
                    PlayerName = player.Email,
                    PlayerRoles = playerRole,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var player = await _playerManager.FindByIdAsync(userId);
            if (player != null)
            {
                var userRoles = await _playerManager.GetRolesAsync(player);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _playerManager.AddToRolesAsync(player, addedRoles);

                await _playerManager.RemoveFromRolesAsync(player, removedRoles);

                return RedirectToAction("PlayersList");
            }
            return NotFound();
        }
    }
}
