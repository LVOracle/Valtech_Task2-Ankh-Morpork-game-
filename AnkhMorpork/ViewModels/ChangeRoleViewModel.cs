using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AnkhMorpork.ViewModels
{
    public class ChangeRoleViewModel
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> PlayerRoles { get; set; }

        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            PlayerRoles = new List<string>();
        }
    }
}
