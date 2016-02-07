using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class AuthorCreateModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 50 characters")]
        public string LocationCoutry { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Death date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeathDate { get; set; }

        public virtual ICollection<UIBook> Books { get; set; }

        public bool IsCreatingNow { get; set; }
    }
}