namespace DAL.Interfacies.DTO
{
    using System.Collections.Generic;

    public class DalGenre : IDalEntity
    {
        public virtual ICollection<DalBook> Books { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}