using System.ComponentModel.DataAnnotations;

namespace AnkhMorpork.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [MaxLength(20)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [MaxLength(20)]
        [Display(Name = "Password")]
        public string OldPassword { get; set; }
    }
}
