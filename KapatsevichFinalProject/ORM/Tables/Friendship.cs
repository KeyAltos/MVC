using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Friendship")]
    public class Friendship : IEntity
    {
        public int Id { get; set; }

        public int FriendOneId { get; set; }
        public User FriendOne { get; set; }

        public int FriendTwoId { get; set; }
        public User FriendTwo { get; set; }

        public bool ApprovedByFriendOne { get; set; }
        public bool ApprovedByFriendTwo { get; set; }
    }
}