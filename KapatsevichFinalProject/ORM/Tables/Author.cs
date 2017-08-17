namespace ORM.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Author")]
    public class Author : IEntity
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public DateTime? DeathDate { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string LocationCoutry { get; set; }
    }
}