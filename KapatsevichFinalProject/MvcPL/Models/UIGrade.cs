using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class UIGrade
    {
        public int Id { get; set; }

        public int AppreiserId { get; set; }
        public UIUser Appreiser { get; set; }

        public int BookId { get; set; }
        public UIBook Book { get; set; }

        [Display(Name = "Grade value")]
        public byte GradeValue { get; set; }

        [Display(Name = "Comment to book")]
        public string Comment { get; set; }

        public bool IsBookHadRead { get; set; }
    }
}