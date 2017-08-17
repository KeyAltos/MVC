namespace DAL.Interfacies.DTO
{
    using System.Collections.Generic;

    public class DalRole : IDalEntity
    {
        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DalUser> Users { get; set; }
    }
}