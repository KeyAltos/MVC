using AutoMapper;
using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class MessageRepository : GenericItemConcreteRepository<Message, DalMessage>
    {
        public MessageRepository(DbContext uow) : base(uow) { }

        public override IEnumerable<DalMessage> GetByPredicate(Expression<Func<DalMessage, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<Message, bool>>>(predicate);
            return Mapper.Map<List<Message>, List<DalMessage>>(dbSet.Where(expression).Include(src => src.Receiver).Include(src => src.Sender).Select(x => x).ToList());
        }
    }
}
