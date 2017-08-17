namespace DAL.Interfacies.DTO
{
    using System.Collections.Generic;

    public class DalBook : IDalEntity
    {
        public DalAuthor Author { get; set; }

        public int AuthorId { get; set; }

        public virtual ICollection<DalGenre> Genres { get; set; }

        public virtual ICollection<DalGrade> Grades { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}