using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;
        public HomeController(IUserService service )
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var l = service.GetAllUserEntities();
            return View(service.GetAllUserEntities()
                .Select(user => new UserViewModel()
                {
                    UserName = user.UserName
                }));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(RegistrationViewModel user)
        {
            var blluser = new UserEntity()
            {
                UserName = user.UserName,
                RoleId = (int)user.Role
            };
            service.CreateUser(blluser);
            return RedirectToAction("Index");
        }
    }
}