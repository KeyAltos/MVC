using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("User")]
    public partial class User : IEntity
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Grades = new HashSet<Grade>();
            Friendships = new HashSet<Friendship>();
        }
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }        

        public DateTime? BirthDate  { get; set; }        

        public string UserName { get; set; }

        public string LocationCoutry { get; set; }

        public string LocationCity { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Friendship> Friendships { get; set; }

    }
}
