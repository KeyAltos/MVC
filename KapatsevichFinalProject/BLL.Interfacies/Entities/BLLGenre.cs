using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BLLGenre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BLLBook> Books { get; set; }
    }
}