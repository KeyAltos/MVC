﻿using AutoMapper;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public class GenericItemConcreteRepository<ORMclass, DALClass> : IRepository<DALClass>
        where ORMclass : class, IEntity
        where DALClass : class, IDalEntity

    {
        protected readonly DbContext context;
        protected readonly DbSet<ORMclass> dbSet;

        public GenericItemConcreteRepository(DbContext uow)
        {
            this.context = uow;
            this.dbSet = uow.Set<ORMclass>();

            Mapper.CreateMap<User, DalUser>();
            Mapper.CreateMap<Role, DalRole>();
            Mapper.CreateMap<Message, DalMessage>();
            Mapper.CreateMap<Author, DalAuthor>();
            Mapper.CreateMap<Book, DalBook>();
            Mapper.CreateMap<Genre, DalGenre>();
            Mapper.CreateMap<Grade, DalGrade>();
            Mapper.CreateMap<Friendship, DalFriendship>();

            Mapper.CreateMap<DalUser, User>();
            Mapper.CreateMap<DalRole, Role>();
            Mapper.CreateMap<DalMessage, Message>();
            Mapper.CreateMap<DalAuthor, Author>();
            Mapper.CreateMap<DalBook, Book>();
            Mapper.CreateMap<DalGenre, Genre>();
            Mapper.CreateMap<DalGrade, Grade>();
            Mapper.CreateMap<DalFriendship, Friendship>();
            Mapper.AssertConfigurationIsValid();
        }

        public void Create(DALClass e)
        {
            var item = Mapper.Map<DALClass, ORMclass>(e);
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var item = dbSet.Find(id);            

            if (item != null)
                dbSet.Remove(item);
            
        }

        public virtual IEnumerable<DALClass> GetAll()
        {            
            return Mapper.Map<List<ORMclass>, List<DALClass>>(dbSet.Select(x => x).ToList());            
        }

        public virtual DALClass GetById(int key)
        {            
            return Mapper.Map<ORMclass, DALClass>(dbSet.FirstOrDefault(item => item.Id == key));
        }

        public virtual IEnumerable<DALClass> GetByPredicate(Expression<Func<DALClass, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<ORMclass, bool>>>(predicate);
            return Mapper.Map<List<ORMclass>, List<DALClass>>(dbSet.Where(expression).Select(x=> x).ToList());
        }

        public void Update(DALClass entity)
        {
            var item = Mapper.Map<DALClass, ORMclass>(entity);
            var dbItem = context.Set<ORMclass>().Find(item.Id);            
            context.Entry(dbItem).CurrentValues.SetValues(item);
            context.Entry<ORMclass>(dbItem).State = EntityState.Modified;
            
        }
    }
}