namespace DependencyResolver
{
    using System.Data.Entity;

    using BLL.Interfacies.Services;
    using BLL.Services;

    using DAL.Concrete;
    using DAL.Interfacies.Repository;

    using Ninject.Modules;

    using ORM;
    using ORM.EntityModel;

    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<EntityModel>();
            this.Bind<IUserRepository>().To<UserRepository>();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind<IUserService>().To<UserService>();
            this.Bind<IRoleService>().To<RoleService>();
            this.Bind<IBookService>().To<BookService>();
            this.Bind<IAuthorService>().To<AuthorService>();
            this.Bind<IGradeService>().To<GradeService>();
            this.Bind<IGenreService>().To<GenreService>();
            this.Bind<IFriendshipService>().To<FriendshipService>();
            this.Bind<IMessageService>().To<MessageService>();
        }
    }
}