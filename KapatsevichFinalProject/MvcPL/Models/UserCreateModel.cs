using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{    
    public class UserCreateModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string Description { get; set; }

        [Display(Name = "Country")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string LocationCoutry { get; set; }

        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string LocationCity { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect adress")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "The length must be from 5 to 50 characters")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length must be from 6 to 50 characters")]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords is incorrect")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length must be from 6 to 50 characters")]
        public string PasswordConfirm { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int RoleId { get; set; }        

        public bool IsCreatingNow { get; set; }

    }
}