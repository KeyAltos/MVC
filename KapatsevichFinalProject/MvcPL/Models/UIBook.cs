using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UIBook
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        public int AuthorId { get; set; }
        public UIAuthor Author { get; set; }

        public virtual ICollection<UIGenre> Genres { get; set; }
        public virtual ICollection<UIGrade> Grades { get; set; }
    }
}