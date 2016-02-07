using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class UserRegisterModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Enter your username")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The length must be from 5 to 50 characters")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length must be from 6 to 50 characters")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat your password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length must be from 6 to 50 characters")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}