namespace ORM.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ORM.Interfaces;

    [Table("Message")]
    public class Message : IEntity
    {
        public int Id { get; set; }

        public DateTime MessageSendingTime { get; set; }

        public string MessageText { get; set; }

        public User Receiver { get; set; }

        public int ReceiverId { get; set; }

        public User Sender { get; set; }

        public int SenderId { get; set; }
    }
}