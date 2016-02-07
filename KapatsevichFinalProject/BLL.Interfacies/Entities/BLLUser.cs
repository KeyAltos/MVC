using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BLLUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LocationCoutry { get; set; }

        public string LocationCity { get; set; }

        public string Description { get; set; }

        public int RoleId { get; set; }
        public virtual BLLRole Role { get; set; }

        public DateTime? BirthDate { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<BLLMessage> Messages { get; set; }

        public virtual ICollection<BLLGrade> Grades { get; set; }

        public virtual ICollection<BLLFriendship> Friendships { get; set; }
    }
}
