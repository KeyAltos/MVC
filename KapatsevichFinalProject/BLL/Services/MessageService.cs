using BLL.Interfacies.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Mappers;

namespace BLL.Services
{
    public class MessageService: IMessageService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalMessage> messageRepository;

        public MessageService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.messageRepository = uow.MessageRepository;
        }

        public void SendMessage(BLLMessage message)
        {
            messageRepository.Create(BllEntityMapper<DalMessage, BLLMessage>.Map(message));
            uow.Commit();
        }

        public void CorrectMessage(BLLMessage message)
        {
            messageRepository.Update(BllEntityMapper<DalMessage, BLLMessage>.Map(message));
            uow.Commit();
        }

        public void DeleteMessage(int messageId)
        {
            messageRepository.Delete(messageId);
            uow.Commit();
        }

        public IEnumerable<BLLMessage> GetUserLastMessages(int Id)
        {
            var tempId = Id;

            var userFullMessageListDAL = messageRepository.GetByPredicate(x =>x.ReceiverId == tempId || x.SenderId == tempId).OrderByDescending(x => x.MessageSendingTime);

            var myMessageFriendsIdList = messageRepository.GetByPredicate(x => x.SenderId == tempId).Select(x => x.ReceiverId).ToList();
            var myMessageFriendsIdToAdd = messageRepository.GetByPredicate(x => x.ReceiverId == tempId).Select(x => x.SenderId).ToList();
            myMessageFriendsIdList.AddRange(myMessageFriendsIdToAdd);
            var finalyMessageListDal = new List<DalMessage>();       
            foreach (var item in myMessageFriendsIdList.Distinct())
            {
                var messageFrom = userFullMessageListDAL.Where(x => x.SenderId == item).FirstOrDefault();               
                var messageFromOrDefaultMessage = messageFrom ?? new DalMessage() { MessageSendingTime = new DateTime(1, 1, 1, 0, 0, 0) };

                var messageTo = userFullMessageListDAL.Where(x => x.ReceiverId == item).FirstOrDefault();                
                var messageToOrDefaultMessage = messageTo ?? new DalMessage() { MessageSendingTime = new DateTime(1, 1, 1, 0, 0, 0) };

                if (messageFromOrDefaultMessage.MessageSendingTime> messageToOrDefaultMessage.MessageSendingTime)
                {
                    finalyMessageListDal.Add(messageFromOrDefaultMessage);
                }
                else
                {
                    finalyMessageListDal.Add(messageToOrDefaultMessage);
                }
            }

            return BllEntityMapper<BLLMessage, DalMessage>.MapList(finalyMessageListDal);
        }

        public IEnumerable<BLLMessage> GetUserToUserMessages(int userOneId, int userTwoId)
        {
            var tempUserOneId = userOneId;
            var tempUserTwoId = userTwoId;
            var userMessageListDAL = messageRepository.GetByPredicate(x => (x.ReceiverId == tempUserOneId && x.SenderId == tempUserTwoId) || (x.ReceiverId == tempUserTwoId && x.SenderId == tempUserOneId)).OrderByDescending(x => x.MessageSendingTime);
            return BllEntityMapper<BLLMessage, DalMessage>.MapList(userMessageListDAL);
        }

        public BLLMessage GetByIdMessage(int Id)
        {
            return BllEntityMapper<BLLMessage, DalMessage>.Map(messageRepository.GetById(Id));
        }
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
