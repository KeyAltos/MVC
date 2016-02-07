using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using AutoMapper;
using System.Collections.Generic;
using BLL.Interfacies.Services;

namespace MvcPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IGradeService gradeService;
        private readonly IBookService bookService;
        private readonly IFriendshipService friendshipService;

        public HomeController(IUserService userService, IRoleService roleService, IGradeService gradeService, IBookService bookService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.gradeService = gradeService;
            this.bookService = bookService;
            this.friendshipService = friendshipService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);
            }
            else
            {
                ViewBag.CurrentUserId = 0;
            }
            
            ViewBag.myFriendsIdList=friendshipService.GetAllMyFriendsId(ViewBag.CurrentUserId);
            
            return View(userService.GetAllUserEntities()
                .Select(user => Mapper.Map<BLLUser, UserIndexModel>(user)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {            
            var view = new UserCreateModel() { IsCreatingNow = true };            
            return View(view);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(UserCreateModel user)
        {
            user.RoleId = 2;
            userService.CreateUser(Mapper.Map<UserCreateModel, BLLUser>(user));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            userService.DeleteUser(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var view = Mapper.Map<BLLUser, UserCreateModel>(userService.GetById(Id));            
            view.IsCreatingNow = false;
            return View("Create", view);
        }

        [HttpPost]
        public ActionResult Edit(UserCreateModel user)
        {
            user.RoleId = 2;
            userService.UpdateUser(Mapper.Map<UserCreateModel, BLLUser>(user));
            return RedirectToAction("Details", "Home", new { Id = userService.GetIdByUsername(user.UserName) });
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            ViewBag.ListAdminId = userService.GetAllAdminsId();
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);
            ViewBag.CurrentUserBooksId = userService.GetAllUserBooksId(ViewBag.CurrentUserId);
            var view = Mapper.Map<BLLUser, UserDetailsModel>(userService.GetById(Id));
            return View(view);

        }        

        [HttpGet]
        public ViewResult AddBookToUser(int Id)
        {
            var view = new GradeCreateModel() { IsCreatingNow = true, BookId=Id, Book = Mapper.Map < BLLBook, UIBook > (bookService.GetById(Id)) };
            return View(view);
        }
        [HttpPost]
        public ActionResult AddBookToUser(GradeCreateModel grade)
        {            
            grade.AppreiserId = userService.GetIdByUsername(User.Identity.Name);
            if (!grade.IsBookHadRead)
            {
                grade.Comment = "";
                grade.GradeValue = 0;
            }
            gradeService.CreateGrade(Mapper.Map <GradeCreateModel,BLLGrade> (grade));
            return RedirectToAction("Details", new { Id = grade.AppreiserId });
        }



        [HttpGet]
        public ActionResult DeleteBookFromUser(int Id)
        {
            gradeService.DeleteGrade(Id);
            var userId = userService.GetIdByUsername(User.Identity.Name);
            return RedirectToAction("Details", new { Id = userId });
        }

        [HttpGet]
        public ActionResult EditGrade(int Id)
        {
            var view = Mapper.Map<BLLGrade, GradeCreateModel>(gradeService.GetById(Id));
            view.IsCreatingNow = false;
            return View("AddBookToUser", view);
        }

        [HttpPost]
        public ActionResult EditGrade(GradeCreateModel grade)
        {            
            gradeService.UpdateGrade(Mapper.Map<GradeCreateModel, BLLGrade>(grade));

            var userId = userService.GetIdByUsername(User.Identity.Name);
            return RedirectToAction("Details", new { Id = userId });
        }
        
        [HttpPost]
        public ActionResult UserSearchPartial(string firstName, string lastName, string locationCountry, string locationCity)
        {
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);

            ViewBag.myFriendsIdList = friendshipService.GetAllMyFriendsId(ViewBag.CurrentUserId);
            
            ViewBag.ListAdminId = userService.GetAllAdminsId();

            var retrievedUsers = userService.SearchUser(firstName, lastName, locationCountry, locationCity);
            
            return PartialView(Mapper.Map<IEnumerable<BLLUser>, IEnumerable<UserIndexModel>>(retrievedUsers));            
        }


        public ActionResult UserSearchIndex()        {
            
            return View();
        }

        public ActionResult ShowUserGrades(int Id)
        {
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);
            ViewBag.CurrentUserBooksId = userService.GetAllUserBooksId(ViewBag.CurrentUserId);
            return View(Mapper.Map<IEnumerable<BLLGrade>, IEnumerable<UIGrade>>(gradeService.GetAllUserGrades(Id)));
        }
        public ActionResult ShowMyGrades()
        {
            var myId= userService.GetIdByUsername(User.Identity.Name);
            return RedirectToAction("ShowUserGrades", new { Id = myId });
        }

        protected override void Dispose(bool disposing)
        {
            roleService.Dispose();
            bookService.Dispose();
            userService.Dispose();
            gradeService.Dispose();
            bookService.Dispose();
            friendshipService.Dispose();            
            base.Dispose(disposing);
        }

    }
}