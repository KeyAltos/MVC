using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using BLL.Mappers;

using AutoMapper;

namespace BLL.Services
{
    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;

    using DAL.Interfacies.DTO;
    using DAL.Interfacies.Repository;

    public class UserService : IUserService
    {
        private IUnitOfWork uow;
        private IUserRepository userRepository;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.userRepository = uow.UserRepository;
            Mapper.AssertConfigurationIsValid();
        }

        public UserService()
        {            
            Mapper.AssertConfigurationIsValid();
        }
        public IEnumerable<BLLUser> GetAllUserEntities()
        {                         
            return BllEntityMapper<BLLUser,DalUser>.MapList(userRepository.GetAll().Select(x => x).ToList());            
        }

        public void CreateUser(BLLUser user)
        {            
            userRepository.Create(BllEntityMapper<DalUser,BLLUser>.Map(user));
            uow.Commit();
        }

        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
            uow.Commit();
        }

        public BLLUser GetById(int userId)
        {
            return BllEntityMapper<BLLUser,DalUser>.Map(userRepository.GetById(userId));            
        }

        public void UpdateUser(BLLUser user)
        {
            userRepository.Update(BllEntityMapper<DalUser,BLLUser>.Map(user));
            uow.Commit();
        }

        public bool CheckUserNameAndPassword(string name, string password)
        {           
            if (userRepository.GetByPredicate(x => x.UserName == name && x.Password == password).Count() == 1)
                return true;
            return false;
        }

        public bool CheckUserName(string name)
        {
            if (userRepository.GetByPredicate(x => x.UserName == name).Count() == 1)
                return true;
            return false;
        }

        public int GetIdByUsername(string name)
        {
            var user = userRepository.GetByPredicate(x => x.UserName == name).FirstOrDefault();
            return user.Id;
        }

        public IEnumerable<int> GetAllUserBooksId(int Id)
        {
            var listAllUserBooksId = new List<int>();
            var user = userRepository.GetById(Id);
            foreach (var item in user.Grades)
            {
                listAllUserBooksId.Add(item.BookId);
            }
            return listAllUserBooksId;
        }

        public IEnumerable<BLLUser> SearchUser(string firstName, string LastName, string locationCountry, string locationCity)
        {
            IEnumerable<DalUser> listOfUsers = userRepository.GetAll();

            if (firstName == "" && LastName == "" && locationCountry == ""&& locationCity=="")
            {
                return BllEntityMapper<BLLUser, DalUser>.MapList(listOfUsers);
            }

            if (firstName != "")
            {
                listOfUsers = userRepository.GetByPredicate(x => x.FirstName == firstName).Select(x => x);
            }            

            if (LastName != "")
            {
                listOfUsers = listOfUsers.Where(x => x.LastName == LastName).Select(x => x);
            }

            if (locationCountry != "")
            {
                listOfUsers = listOfUsers.Where(x => x.LocationCoutry == locationCountry).Select(x => x);
            }

            if (locationCity != "")
            {
                listOfUsers = listOfUsers.Where(x => x.LocationCity == locationCity).Select(x => x);
            }

            return BllEntityMapper<BLLUser, DalUser>.MapList(listOfUsers);


        }

        public string GetUserRoleByUsername(string username)
        {
            var roleName = userRepository.GetByPredicate(x => x.UserName == username).Select(x=>x.Role.Name).FirstOrDefault();
            return roleName;
        }

        public IEnumerable<int> GetAllAdminsId()
        {
            return userRepository.GetByPredicate(x => x.RoleId == 1).Select(x => x.Id).ToList();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
