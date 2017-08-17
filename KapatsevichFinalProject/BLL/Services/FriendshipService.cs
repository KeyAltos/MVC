using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Interfacies.Repository;

using BLL.Mappers;

namespace BLL.Services
{
    using BLL.Interfacies.Entities;

    using DAL.Interfacies.DTO;

    public class FriendshipService : IFriendshipService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalFriendship> friendshipRepository;

        public FriendshipService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.friendshipRepository = uow.FriendshipRepository;
        }

        public void ApproveFriendshipRequest(int friendshipId)
        {
            var friendshipForApprove=friendshipRepository.GetById(friendshipId);
            friendshipForApprove.ApprovedByFriendTwo = true;
            friendshipRepository.Update(friendshipForApprove);
            uow.Commit();
        }

        public void CreateFriendshipRequest(int friendOneId, int friendTwoId)
        {
            var newFriendhip= new DalFriendship()
            {
                FriendOneId = friendOneId,
                FriendTwoId = friendTwoId,
                ApprovedByFriendOne = true
            };
            friendshipRepository.Create(newFriendhip);
            uow.Commit();
        }

        public IEnumerable<BLLFriendship> GetUserFriendshipEntities(int Id)
        {
            var tempId = Id;
            
            var userFriendshipListDAL = friendshipRepository.GetByPredicate(x => (x.FriendOneId == tempId || x.FriendTwoId == tempId) &&(x.ApprovedByFriendOne&&x.ApprovedByFriendTwo));
            return BllEntityMapper<BLLFriendship, DalFriendship>.MapList(userFriendshipListDAL);
             
        }

        public IEnumerable<BLLFriendship> GetUserFriendshipRequests(int Id)
        {
            var tempId = Id;

            var userFriendshipListDAL = friendshipRepository.GetByPredicate(x => (x.FriendOneId == tempId || x.FriendTwoId == tempId) && (x.ApprovedByFriendOne ^ x.ApprovedByFriendTwo));
            return BllEntityMapper<BLLFriendship, DalFriendship>.MapList(userFriendshipListDAL);
            
        }

        public void DeleteFromFriensds(int friendshipId)
        {
            friendshipRepository.Delete(friendshipId);
            uow.Commit();
        }

        public IEnumerable<int> GetAllMyFriendsId(int Id)
        {
            var tempId = Id;            
            var myFriendsIdList = friendshipRepository.GetByPredicate(x => x.FriendOneId == tempId).Select(x => x.FriendTwoId).ToList();            
            var myFriendsIdToAdd = friendshipRepository.GetByPredicate(x => x.FriendTwoId == tempId).Select(x => x.FriendOneId).ToList();
            
            myFriendsIdList.AddRange(myFriendsIdToAdd);                       

            return myFriendsIdList;
        }
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
