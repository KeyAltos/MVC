namespace BLL.Interfacies.Entities
{
    using System.Collections.Generic;

    public class BLLGenre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BLLBook> Books { get; set; }
    }
}