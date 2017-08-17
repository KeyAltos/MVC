namespace DAL.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper;

    using DAL.Interfacies.DTO;

    using ORM;
    using ORM.Tables;

    class FriendshipRepository : GenericItemConcreteRepository<Friendship, DalFriendship>
    {
        public FriendshipRepository(DbContext uow)
            : base(uow)
        {
        }

        public override IEnumerable<DalFriendship> GetByPredicate(Expression<Func<DalFriendship, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<Friendship, bool>>>(predicate);
            return
                Mapper.Map<List<Friendship>, List<DalFriendship>>(
                    this.dbSet.Where(expression)
                        .Include(src => src.FriendOne)
                        .Include(src => src.FriendTwo)
                        .Select(x => x)
                        .ToList());
        }
    }
}