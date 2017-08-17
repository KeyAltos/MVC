namespace DAL.Interfacies.DTO
{
    using System;
    using System.Collections.Generic;

    public class DalUser : IDalEntity
    {
        public DateTime? BirthDate { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public virtual ICollection<DalFriendship> Friendships { get; set; }

        public virtual ICollection<DalGrade> Grades { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string LocationCity { get; set; }

        public string LocationCoutry { get; set; }

        public virtual ICollection<DalMessage> Messages { get; set; }

        public string Password { get; set; }

        public virtual DalRole Role { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; }
    }
}