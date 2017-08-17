namespace ORM.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("User")]
    public partial class User : IEntity
    {
        public User()
        {
            this.Messages = new HashSet<Message>();
            this.Grades = new HashSet<Grade>();
            this.Friendships = new HashSet<Friendship>();
        }

        public DateTime? BirthDate { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        // [Required]
        // [StringLength(50)]
        public string FirstName { get; set; }

        public virtual ICollection<Friendship> Friendships { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string LocationCity { get; set; }

        public string LocationCoutry { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public string Password { get; set; }

        public virtual Role Role { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; }
    }
}