using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalBook : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }
        public DalAuthor Author { get; set; }

        public virtual ICollection<DalGenre> Genres { get; set; }

        public virtual ICollection<DalGrade> Grades { get; set; }
    }
}