using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IMessageService
    {
        void SendMessage(BLLMessage message);
        void CorrectMessage(BLLMessage message);
        void DeleteMessage(int messageId);

        BLLMessage GetByIdMessage(int Id);

        IEnumerable<BLLMessage> GetUserLastMessages(int Id);
        IEnumerable<BLLMessage> GetUserToUserMessages(int userOneId, int userTwoId);
        void Dispose();
        

    }
}
