using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserLoginModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Enter your username")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The length must be from 5 to 50 characters")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Enter your password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length must be from 6 to 50 characters")]
        public string Password { get; set; }
    }
}