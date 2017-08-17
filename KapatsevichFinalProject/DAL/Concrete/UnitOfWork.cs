namespace DAL.Concrete
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    using DAL.Interfacies.DTO;
    using DAL.Interfacies.Repository;

    using ORM;
    using ORM.Tables;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private GenericItemConcreteRepository<Author, DalAuthor> authorRepository;

        private IBookRepository bookRepository;

        private GenericItemConcreteRepository<Friendship, DalFriendship> friendshipRepository;

        private GenericItemConcreteRepository<Genre, DalGenre> genreRepository;

        private GenericItemConcreteRepository<Grade, DalGrade> gradeRepository;

        private GenericItemConcreteRepository<Message, DalMessage> messageRepository;

        private GenericItemConcreteRepository<Role, DalRole> roleRepository;

        private IUserRepository userRepository;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        public IRepository<DalAuthor> AuthorRepository
        {
            get
            {
                if (this.authorRepository == null)
                    this.authorRepository = new GenericItemConcreteRepository<Author, DalAuthor>(this.Context);
                return this.authorRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                    this.bookRepository = new BookRepository(this.Context);
                return this.bookRepository;
            }
        }

        public DbContext Context { get; private set; }

        public IRepository<DalFriendship> FriendshipRepository
        {
            get
            {
                if (this.friendshipRepository == null)
                    this.friendshipRepository = new FriendshipRepository(this.Context);
                return this.friendshipRepository;
            }
        }

        public IRepository<DalGenre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                    this.genreRepository = new GenericItemConcreteRepository<Genre, DalGenre>(this.Context);
                return this.genreRepository;
            }
        }

        public IRepository<DalGrade> GradeRepository
        {
            get
            {
                if (this.gradeRepository == null)
                    this.gradeRepository = new GradeRepository(this.Context);
                return this.gradeRepository;
            }
        }

        public IRepository<DalMessage> MessageRepository
        {
            get
            {
                if (this.messageRepository == null)
                    this.messageRepository = new MessageRepository(this.Context);
                return this.messageRepository;
            }
        }

        public IRepository<DalRole> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                    this.roleRepository = new GenericItemConcreteRepository<Role, DalRole>(this.Context);
                return this.roleRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new UserRepository(this.Context);
                return this.userRepository;
            }
        }

        public void Commit()
        {
            if (this.Context != null)
            {
                try
                {
                    this.Context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                "Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}