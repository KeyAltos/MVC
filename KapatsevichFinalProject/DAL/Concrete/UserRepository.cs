namespace DAL.Concrete
{
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using DAL.Interfacies.DTO;
    using DAL.Interfacies.Repository;

    using ORM;
    using ORM.Tables;

    public class UserRepository : GenericItemConcreteRepository<User, DalUser>, IUserRepository
    {
        public UserRepository(DbContext uow)
            : base(uow)
        {
        }

        public override DalUser GetById(int key)
        {
            return
                Mapper.Map<User, DalUser>(
                    this.dbSet.Include(u => u.Grades.Select(X => X.Book).Select(y => y.Author))
                        .FirstOrDefault(item => item.Id == key));
        }
    }
}