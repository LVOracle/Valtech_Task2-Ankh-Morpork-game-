﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkhMorpork.ViewModels
{
    public class CreatePlayerViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [MaxLength(20)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
