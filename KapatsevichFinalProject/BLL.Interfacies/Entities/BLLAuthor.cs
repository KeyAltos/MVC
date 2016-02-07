using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BLLAuthor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LocationCoutry { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public virtual ICollection<BLLBook> Books { get; set; }
    }
}