using DAL.Interface.DTO;
using DAL.Interfacies.Repository;
using System;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRepository<DalRole> RoleRepository { get; }

        IRepository<DalAuthor> AuthorRepository { get; }        
        IBookRepository BookRepository { get; }
        IRepository<DalFriendship> FriendshipRepository { get; }
        IRepository<DalGenre> GenreRepository { get; }
        IRepository<DalGrade> GradeRepository { get; }
        IRepository<DalMessage> MessageRepository { get; }

        void Commit();
    }
}
