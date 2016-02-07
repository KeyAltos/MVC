using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BLLBook
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }
        public BLLAuthor Author { get; set; }

        public virtual ICollection<BLLGenre> Genres { get; set; }

        public virtual ICollection<BLLGrade> Grades { get; set; }
    }
}