namespace MvcPL.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;

    using MvcPL.Models;

    [Authorize]
    public class FriendshipController : Controller
    {
        // GET: /Friendship/
        private readonly IFriendshipService friendshipService;

        private readonly IUserService userService;

        public FriendshipController(IFriendshipService friendshipService, IUserService userService)
        {
            this.friendshipService = friendshipService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult AddUserToMyFriend(int Id)
        {
            this.friendshipService.CreateFriendshipRequest(
                this.userService.GetIdByUsername(this.User.Identity.Name),
                Id);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ApproveFriendshipRequest(int Id)
        {
            this.friendshipService.ApproveFriendshipRequest(Id);
            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            this.friendshipService.DeleteFromFriensds(Id);
            return this.RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var myId = this.userService.GetIdByUsername(this.User.Identity.Name);
            var view =
                Mapper.Map<IEnumerable<BLLFriendship>, List<UIFriendship>>(
                    this.friendshipService.GetUserFriendshipEntities(myId));
            this.ViewBag.CurrentUserFriendhipRequestCount =
                this.friendshipService.GetUserFriendshipRequests(myId).Count();
            this.ViewBag.CurrentUserId = myId;
            return this.View(view);
        }

        public ActionResult MyFriendshipRequests()
        {
            var a =
                this.friendshipService.GetUserFriendshipRequests(
                    this.userService.GetIdByUsername(this.User.Identity.Name));
            var b = Mapper.Map<IEnumerable<BLLFriendship>, List<UIFriendship>>(a);
            this.ViewBag.CurrentUserId = this.userService.GetIdByUsername(this.User.Identity.Name);
            return this.View(b);
        }

        protected override void Dispose(bool disposing)
        {
            this.friendshipService.Dispose();
            this.userService.Dispose();
            base.Dispose(disposing);
        }
    }
}