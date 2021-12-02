using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnkhMorpork.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are mot equal!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm passwords")]
        public string PasswordConfirm { get; set; }

    }
}
