using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalGenre : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DalBook> Books { get; set; }
    }
}