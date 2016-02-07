using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BLLRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<BLLUser> Users { get; set; }
    }
}