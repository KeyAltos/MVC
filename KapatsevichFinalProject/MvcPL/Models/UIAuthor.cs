using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class UIAuthor
    {
        public int Id { get; set; }

        [Display(Name = "Author first name")]
        public string FirstName { get; set; }

        [Display(Name = "Author last name")]
        public string LastName { get; set; }

        [Display(Name = "Country")]
        public string LocationCoutry { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Death date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeathDate { get; set; }

        public virtual ICollection<UIBook> Books { get; set; }
    }
}