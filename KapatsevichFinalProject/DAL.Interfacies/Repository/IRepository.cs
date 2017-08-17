namespace DAL.Interfacies.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using DAL.Interfacies.DTO;

    public interface IRepository<TEntity>
        where TEntity : IDalEntity
    {
        void Create(TEntity e);

        void Delete(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int key);

        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);
    }
}