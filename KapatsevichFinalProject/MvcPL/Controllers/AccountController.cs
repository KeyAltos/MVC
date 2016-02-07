using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (userService.CheckUserNameAndPassword(model.UserName, model.Password))
                {                                      
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    var myId = userService.GetIdByUsername(model.UserName);
                    return RedirectToAction("Details", "Home", new { Id = myId });
                }
                else
                {
                    ModelState.AddModelError("", "There is not user with such username and password");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {            
            FormsAuthentication.SignOut();
            return RedirectToAction("StartPage");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (!userService.CheckUserName(model.UserName))
                {
                    model.RoleId = 2;
                    userService.CreateUser(Mapper.Map<UserRegisterModel, BLLUser>(model));
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    
                    return RedirectToAction("Edit", "Home", new { Id = userService.GetIdByUsername(model.UserName) });                                        
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

        public ActionResult StartPage()
        {
            
            if (User.Identity.IsAuthenticated)
            {                
                return RedirectToAction("Details", "Home", new { Id = userService.GetIdByUsername(User.Identity.Name) });
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {            
            userService.Dispose();            
            base.Dispose(disposing);
        }

    }
}