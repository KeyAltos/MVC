using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class UserDetailsModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Description { get; set; }

        [Display(Name = "Country")]
        public string LocationCoutry { get; set; }

        [Display(Name = "City")]
        public string LocationCity { get; set; }

        public virtual ICollection<UIGrade> Grades { get; set; }

        public virtual ICollection<UIFriendship> Friendships { get; set; }
    }
}