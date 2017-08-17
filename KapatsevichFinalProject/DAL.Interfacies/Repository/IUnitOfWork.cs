namespace DAL.Interfacies.Repository
{
    using System;

    using DAL.Interfacies.DTO;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<DalAuthor> AuthorRepository { get; }

        IBookRepository BookRepository { get; }

        IRepository<DalFriendship> FriendshipRepository { get; }

        IRepository<DalGenre> GenreRepository { get; }

        IRepository<DalGrade> GradeRepository { get; }

        IRepository<DalMessage> MessageRepository { get; }

        IRepository<DalRole> RoleRepository { get; }

        IUserRepository UserRepository { get; }

        void Commit();
    }
}