using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalRole : IDalEntity
    {
        public int Id { get; set; }
                
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<DalUser> Users { get; set; }
    }
}
