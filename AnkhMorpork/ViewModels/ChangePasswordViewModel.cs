using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
