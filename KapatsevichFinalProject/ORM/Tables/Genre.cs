namespace ORM.Tables
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Genre")]
    public class Genre : IEntity
    {
        public Genre()
        {
            this.Books = new HashSet<Book>();
        }

        public virtual ICollection<Book> Books { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}