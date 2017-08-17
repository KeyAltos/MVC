namespace ORM.Tables
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Book")]
    public class Book : IEntity
    {
        public Book()
        {
            this.Genres = new HashSet<Genre>();
            this.Grades = new HashSet<Grade>();
        }

        public Author Author { get; set; }

        public int AuthorId { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}