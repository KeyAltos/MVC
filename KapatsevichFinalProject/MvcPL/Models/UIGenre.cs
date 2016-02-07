using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class UIGenre
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length is 3-50 char")]
        public string Name { get; set; }

        public virtual ICollection<UIBook> Books { get; set; }
    }
}