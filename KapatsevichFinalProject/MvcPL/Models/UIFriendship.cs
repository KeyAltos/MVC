namespace MvcPL.Models
{
    public class UIFriendship
    {
        public int Id { get; set; }

        public int FriendOneId { get; set; }
        public UIUser FriendOne { get; set; }

        public int FriendTwoId { get; set; }
        public UIUser FriendTwo { get; set; }

        public bool ApprovedByFriendOne { get; set; }
        public bool ApprovedByFriendTwo { get; set; }
    }
}