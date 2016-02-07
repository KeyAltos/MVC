using System.Data.Entity;
using BLL.Interface;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject.Modules;
using ORM;
using BLL.Interfacies.Services;

namespace DependencyResolver
{
    public class RevolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EntityModel>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IBookService>().To<BookService>();
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IGradeService>().To<GradeService>();
            Bind<IGenreService>().To<GenreService>();
            Bind<IFriendshipService>().To<FriendshipService>();
            Bind<IMessageService>().To<MessageService>();
        }
    }
}