using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class BookCreateModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length is 3-50 char")]
        public string Name { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public IEnumerable<AuthorForBookModel> ListOfAuthors { get; set; }

        public bool IsCreatingNow { get; set; }

        public virtual ICollection<UIGenre> Genres { get; set; }

        //public virtual ICollection<BLLGrade> Grades { get; set; }
    }
}