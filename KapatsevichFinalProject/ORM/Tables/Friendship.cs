namespace ORM.Tables
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Friendship")]
    public class Friendship : IEntity
    {
        public bool ApprovedByFriendOne { get; set; }

        public bool ApprovedByFriendTwo { get; set; }

        public User FriendOne { get; set; }

        public int FriendOneId { get; set; }

        public User FriendTwo { get; set; }

        public int FriendTwoId { get; set; }

        public int Id { get; set; }
    }
}