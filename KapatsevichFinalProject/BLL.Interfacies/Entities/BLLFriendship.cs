namespace BLL.Interfacies.Entities
{
    public class BLLFriendship
    {
        public int Id { get; set; }

        public int FriendOneId { get; set; }
        public BLLUser FriendOne { get; set; }

        public int FriendTwoId { get; set; }
        public BLLUser FriendTwo { get; set; }

        public bool ApprovedByFriendOne { get; set; }
        public bool ApprovedByFriendTwo { get; set; }
    }
}