using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : IDalEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LocationCoutry { get; set; }

        public string LocationCity { get; set; }

        public string Description { get; set; }

        public int RoleId { get; set; }
        public virtual DalRole Role { get; set; }

        public DateTime? BirthDate { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<DalMessage> Messages { get; set; }

        public virtual ICollection<DalGrade> Grades { get; set; }

        public virtual ICollection<DalFriendship> Friendships { get; set; }
    }
}