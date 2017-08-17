namespace BLL.Interfacies.Entities
{
    using System;

    public class BLLMessage
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public BLLUser Sender { get; set; }

        public int ReceiverId { get; set; }
        public BLLUser Receiver { get; set; }

        public DateTime MessageSendingTime { get; set; }

        public string MessageText { get; set; }
    }
}