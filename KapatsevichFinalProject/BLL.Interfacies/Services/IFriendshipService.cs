using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IFriendshipService
    {
        IEnumerable<BLLFriendship> GetUserFriendshipEntities(int Id);
        IEnumerable<BLLFriendship> GetUserFriendshipRequests(int Id);

        IEnumerable<int> GetAllMyFriendsId(int Id);

        void CreateFriendshipRequest(int friendOneId, int friendTwoId);
        void ApproveFriendshipRequest(int friendshipId);
        void DeleteFromFriensds(int friendshipId);
        void Dispose();
    }
}
