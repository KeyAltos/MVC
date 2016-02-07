using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class UIMessage
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public UIUser Sender { get; set; }

        public int ReceiverId { get; set; }
        public UIUser Receiver { get; set; }

        [Required]     
        [Display(Name = "Message sending time")]
        public DateTime MessageSendingTime { get; set; }

        [Display(Name = "Message text")]
        public string MessageText { get; set; }
    }
}