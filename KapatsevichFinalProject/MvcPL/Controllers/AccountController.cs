namespace MvcPL.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using AutoMapper;

    using BLL.Interface.Entities;
    using BLL.Interface.Services;

    using MvcPL.Models;

    public class AccountController : Controller
    {
        // GET: /Account/
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.userService.CheckUserNameAndPassword(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    var myId = this.userService.GetIdByUsername(model.UserName);
                    return this.RedirectToAction("Details", "Home", new { Id = myId });
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "There is not user with such username and password");
                }
            }

            return this.View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("StartPage");
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.userService.CheckUserName(model.UserName))
                {
                    model.RoleId = 2;
                    this.userService.CreateUser(Mapper.Map<UserRegisterModel, BLLUser>(model));
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                    return this.RedirectToAction(
                        "Edit",
                        "Home",
                        new { Id = this.userService.GetIdByUsername(model.UserName) });
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Пользователь с таким логином уже существует");
                }
            }

            return this.View(model);
        }

        public ActionResult StartPage()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction(
                    "Details",
                    "Home",
                    new { Id = this.userService.GetIdByUsername(this.User.Identity.Name) });
            }

            return this.View();
        }

        protected override void Dispose(bool disposing)
        {
            this.userService.Dispose();
            base.Dispose(disposing);
        }
    }
}