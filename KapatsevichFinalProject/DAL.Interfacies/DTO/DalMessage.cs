namespace DAL.Interfacies.DTO
{
    using System;

    public class DalMessage : IDalEntity
    {
        public int Id { get; set; }

        public DateTime MessageSendingTime { get; set; }

        public string MessageText { get; set; }

        public DalUser Receiver { get; set; }

        public int ReceiverId { get; set; }

        public DalUser Sender { get; set; }

        public int SenderId { get; set; }
    }
}