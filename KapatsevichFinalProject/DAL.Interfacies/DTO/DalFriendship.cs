namespace DAL.Interface.DTO
{
    public class DalFriendship : IDalEntity
    {
        public int Id { get; set; }

        public int FriendOneId { get; set; }
        public DalUser FriendOne { get; set; }

        public int FriendTwoId { get; set; }
        public DalUser FriendTwo { get; set; }

        public bool ApprovedByFriendOne { get; set; }
        public bool ApprovedByFriendTwo { get; set; }
    }
}