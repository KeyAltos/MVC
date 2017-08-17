namespace ORM.Tables
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Role")]
    public partial class Role : IEntity
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public string Description { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}