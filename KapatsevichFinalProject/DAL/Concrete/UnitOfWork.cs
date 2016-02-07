using System;
using System.Data.Entity;
using System.Diagnostics;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System.Data.Entity.Validation;
using DAL.Interfacies.Repository;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContext Context { get; private set; }

        private IUserRepository                                             userRepository;
        private GenericItemConcreteRepository<Role, DalRole>                roleRepository;
        private GenericItemConcreteRepository<Author, DalAuthor>            authorRepository;        
        private IBookRepository                                             bookRepository;
        private GenericItemConcreteRepository<Genre, DalGenre>              genreRepository;
        private GenericItemConcreteRepository<Grade, DalGrade>              gradeRepository;
        private GenericItemConcreteRepository<Message, DalMessage>          messageRepository;
        private GenericItemConcreteRepository<Friendship, DalFriendship>    friendshipRepository;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(Context);
                return userRepository;
            }
        }

        public IRepository<DalRole> RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new GenericItemConcreteRepository<Role, DalRole>(Context);
                return roleRepository;
            }
        }

        public IRepository<DalAuthor> AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new GenericItemConcreteRepository<Author, DalAuthor>(Context);
                return authorRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (bookRepository == null)                    
                    bookRepository = new BookRepository(Context);
                return bookRepository;
            }
        }

        public IRepository<DalFriendship> FriendshipRepository
        {
            get
            {
                if (friendshipRepository == null)                    
                    friendshipRepository = new FriendshipRepository(Context);
                return friendshipRepository;
            }
        }

        public IRepository<DalGenre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenericItemConcreteRepository<Genre, DalGenre>(Context);
                return genreRepository;
            }
        }

        public IRepository<DalGrade> GradeRepository
        {
            get
            {
                if (gradeRepository == null)
                    gradeRepository = new GradeRepository(Context);                    
                return gradeRepository;
            }
        }

        public IRepository<DalMessage> MessageRepository
        {
            get
            {
                if (messageRepository == null)                    
                    messageRepository = new MessageRepository(Context); 
                return messageRepository;
            }
        }        

        public void Commit()
        {
            if (Context != null)
            {
                try {
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);           
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
