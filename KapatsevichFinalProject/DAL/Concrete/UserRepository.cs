using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using AutoMapper;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public class UserRepository : GenericItemConcreteRepository<User, DalUser>, IUserRepository
    {
        public UserRepository(DbContext uow) : base(uow) { }

        public override DalUser GetById(int key)
        {            
            return Mapper.Map<User, DalUser>(dbSet.Include(u => u.Grades.Select(X => X.Book).Select(y => y.Author)).FirstOrDefault(item => item.Id == key));
        }
    }
}
