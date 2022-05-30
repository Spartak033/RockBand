﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockBand.Models
{
    public class LoginModal
    {
        [Required]
        [StringLength(100,MinimumLength =2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
     [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
   
        public string LoginInValid { get; set; }

    }
}
