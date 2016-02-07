using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Interfacies.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize]
    public class FriendshipController : Controller
    {
        //
        // GET: /Friendhip/
        private readonly IFriendshipService friendshipService;
        private readonly IUserService userService;


        public FriendshipController(IFriendshipService friendshipService, IUserService userService)
        {
            this.friendshipService = friendshipService;
            this.userService = userService;

        }

        public ActionResult Index()
        {
            var myId = userService.GetIdByUsername(User.Identity.Name);
            var view = Mapper.Map < IEnumerable<BLLFriendship>, List<UIFriendship> > (friendshipService.GetUserFriendshipEntities(myId));

            ViewBag.CurrentUserId = myId;            
            return View(view);            
        }

        public ActionResult MyFriendshipRequests()
        {
            var a = friendshipService.GetUserFriendshipRequests(userService.GetIdByUsername(User.Identity.Name));
            var b = Mapper.Map<IEnumerable<BLLFriendship>, List<UIFriendship>>(a);
            ViewBag.CurrentUserId = userService.GetIdByUsername(User.Identity.Name);
            return View(b);
        }

        [HttpGet]
        public ActionResult AddUserToMyFriend(int Id)
        {
            friendshipService.CreateFriendshipRequest(userService.GetIdByUsername(User.Identity.Name),Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ApproveFriendshipRequest(int Id)
        {
            friendshipService.ApproveFriendshipRequest(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            friendshipService.DeleteFromFriensds(Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            friendshipService.Dispose();            
            userService.Dispose();            
            base.Dispose(disposing);
        }

    }
}
