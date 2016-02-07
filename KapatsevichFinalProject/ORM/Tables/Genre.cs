using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Genre")]
    public class Genre : IEntity
    {
        public Genre()
        {
            Books = new HashSet<Book>();            
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}