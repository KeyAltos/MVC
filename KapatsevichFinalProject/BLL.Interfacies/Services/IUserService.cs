namespace BLL.Interfacies.Services
{
    using System.Collections.Generic;

    using BLL.Interfacies.Entities;

    public interface IUserService
    {
        IEnumerable<BLLUser> GetAllUserEntities();
        void CreateUser(BLLUser user);
        void DeleteUser(int userId);
        BLLUser GetById(int userId);
        void UpdateUser(BLLUser user);
        bool CheckUserNameAndPassword(string name, string password);
        bool CheckUserName(string name);
        int GetIdByUsername(string name);

        string GetUserRoleByUsername(string username);

        IEnumerable<int> GetAllUserBooksId(int Id);

        IEnumerable<int> GetAllAdminsId();

        IEnumerable<BLLUser> SearchUser(string firstName, string LastName, string locationCountry, string locationCity);
        void Dispose();
    }
        
}