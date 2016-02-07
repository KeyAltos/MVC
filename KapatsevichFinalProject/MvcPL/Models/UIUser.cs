using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class UIUser
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public int RoleId { get; set; }
        public virtual UIRole Role { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Country")]
        public string LocationCoutry { get; set; }

        [Display(Name = "City")]
        public string LocationCity { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UIMessage> Messages { get; set; }

        public virtual ICollection<UIGrade> Grades { get; set; }

        public virtual ICollection<UIFriendship> Friendships { get; set; }
    }
}