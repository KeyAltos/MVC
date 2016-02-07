using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class BookIndexModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        public int AuthorId { get; set; }
        
        public AuthorForBookModel Author { get; set; }

    }
}