using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    [Table("Book")]
    public class Book : IEntity
    {
        public Book()
        {
            Genres = new HashSet<Genre>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
