namespace DAL.Interfacies.DTO
{
    using System;
    using System.Collections.Generic;

    public class DalAuthor : IDalEntity
    {
        public DateTime BirthDate { get; set; }

        public virtual ICollection<DalBook> Books { get; set; }

        public DateTime? DeathDate { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string LocationCoutry { get; set; }
    }
}