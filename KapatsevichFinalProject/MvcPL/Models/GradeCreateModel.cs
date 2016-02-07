using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class GradeCreateModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int AppreiserId { get; set; }
        public UIUser Appreiser { get; set; }

        public int BookId { get; set; }
        public UIBook Book { get; set; }

        [Range(0, 5, ErrorMessage = "Grade value must be from 0 to 5")]        
        [Display(Name = "Grade value")]
        public byte GradeValue { get; set; }

        [Display(Name = "Comment to book")]
        public string Comment { get; set; }

        [Display(Name = "I read this book?")]
        public bool IsBookHadRead { get; set; }

        public bool IsCreatingNow { get; set; }
    }
}