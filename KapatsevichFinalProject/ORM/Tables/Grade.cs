namespace ORM.Tables
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Grade")]
    public class Grade : IEntity
    {
        public User Appreiser { get; set; }

        public int AppreiserId { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

        public string Comment { get; set; }

        public byte GradeValue { get; set; }

        public int Id { get; set; }

        public bool IsBookHadRead { get; set; }
    }
}