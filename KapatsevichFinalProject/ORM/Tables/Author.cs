using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ORM
{
    [Table("Author")]
    public class Author: IEntity
    {

        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LocationCoutry { get; set; }
        
        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}