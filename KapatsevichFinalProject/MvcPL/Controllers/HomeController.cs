namespace MvcPL.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using BLL.Interface.Entities;
    using BLL.Interface.Services;
    using BLL.Interfacies.Services;

    using MvcPL.Models;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        private readonly IFriendshipService friendshipService;

        private readonly IGradeService gradeService;

        private readonly IRoleService roleService;

        private readonly IUserService userService;

        public HomeController(
            IUserService userService,
            IRoleService roleService,
            IGradeService gradeService,
            IBookService bookService,
            IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.gradeService = gradeService;
            this.bookService = bookService;
            this.friendshipService = friendshipService;
        }

        [HttpGet]
        public ViewResult AddBookToUser(int Id)
        {
            var view = new GradeCreateModel()
                           {
                               IsCreatingNow = true,
                               BookId = Id,
                               Book = Mapper.Map<BLLBook, UIBook>(this.bookService.GetById(Id))
                           };
            return this.View(view);
        }

        [HttpPost]
        public ActionResult AddBookToUser(GradeCreateModel grade)
        {
            grade.AppreiserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            if (!grade.IsBookHadRead)
            {
                grade.Comment = string.Empty;
                grade.GradeValue = 0;
            }

            this.gradeService.CreateGrade(Mapper.Map<GradeCreateModel, BLLGrade>(grade));
            return this.RedirectToAction("Details", new { Id = grade.AppreiserId });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var view = new UserCreateModel() { IsCreatingNow = true };
            return this.View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(UserCreateModel user)
        {
            user.RoleId = 2;
            this.userService.CreateUser(Mapper.Map<UserCreateModel, BLLUser>(user));
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            this.userService.DeleteUser(Id);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteBookFromUser(int Id)
        {
            this.gradeService.DeleteGrade(Id);
            var userId = this.userService.GetIdByUsername(this.User.Identity.Name);
            return this.RedirectToAction("Details", new { Id = userId });
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            this.ViewBag.ListAdminId = this.userService.GetAllAdminsId();
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            this.ViewBag.CurrentUserBooksId = this.userService.GetAllUserBooksId(this.ViewBag.CurrentUserId);
            var view = Mapper.Map<BLLUser, UserDetailsModel>(this.userService.GetById(Id));
            return this.View(view);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLUser, UserCreateModel>(this.userService.GetById(Id));
            view.IsCreatingNow = false;
            return this.View("Create", view);
        }

        [HttpPost]
        public ActionResult Edit(UserCreateModel user)
        {
            user.RoleId = 2;
            this.userService.UpdateUser(Mapper.Map<UserCreateModel, BLLUser>(user));
            return this.RedirectToAction(
                "Details",
                "Home",
                new { Id = this.userService.GetIdByUsername(user.UserName) });
        }

        [HttpGet]
        public ActionResult EditGrade(int Id)
        {
            var view = Mapper.Map<BLLGrade, GradeCreateModel>(this.gradeService.GetById(Id));
            view.IsCreatingNow = false;
            return this.View("AddBookToUser", view);
        }

        [HttpPost]
        public ActionResult EditGrade(GradeCreateModel grade)
        {
            this.gradeService.UpdateGrade(Mapper.Map<GradeCreateModel, BLLGrade>(grade));

            var userId = this.userService.GetIdByUsername(this.User.Identity.Name);
            return this.RedirectToAction("Details", new { Id = userId });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            }
            else
            {
                this.ViewBag.CurrentUserId = 0;
            }

            this.ViewBag.myFriendsIdList = this.friendshipService.GetAllMyFriendsId(this.ViewBag.CurrentUserId);

            return
                this.View(
                    this.userService.GetAllUserEntities().Select(user => Mapper.Map<BLLUser, UserIndexModel>(user)));
        }

        public ActionResult ShowMyGrades()
        {
            var myId = this.userService.GetIdByUsername(this.User.Identity.Name);
            return this.RedirectToAction("ShowUserGrades", new { Id = myId });
        }

        public ActionResult ShowUserGrades(int Id)
        {
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            this.ViewBag.CurrentUserBooksId = this.userService.GetAllUserBooksId(this.ViewBag.CurrentUserId);
            return
                this.View(
                    Mapper.Map<IEnumerable<BLLGrade>, IEnumerable<UIGrade>>(this.gradeService.GetAllUserGrades(Id)));
        }

        public ActionResult UserSearchIndex()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult UserSearchPartial(
            string firstName,
            string lastName,
            string locationCountry,
            string locationCity)
        {
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);

            this.ViewBag.myFriendsIdList = this.friendshipService.GetAllMyFriendsId(this.ViewBag.CurrentUserId);

            this.ViewBag.ListAdminId = this.userService.GetAllAdminsId();

            var retrievedUsers = this.userService.SearchUser(firstName, lastName, locationCountry, locationCity);

            return this.PartialView(Mapper.Map<IEnumerable<BLLUser>, IEnumerable<UserIndexModel>>(retrievedUsers));
        }

        protected override void Dispose(bool disposing)
        {
            this.roleService.Dispose();
            this.bookService.Dispose();
            this.userService.Dispose();
            this.gradeService.Dispose();
            this.bookService.Dispose();
            this.friendshipService.Dispose();
            base.Dispose(disposing);
        }
    }
}